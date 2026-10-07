The Release workflow uses the headless Certum integration described in the
[ssign GitHub Actions guide](https://le-syl21.github.io/ssign/github-actions.html).
It runs on an Ubuntu runner and retains the existing `release` environment.
The signing job is part of the build/sign/publish dependency chain.

These artifacts are NuGet packages, so signing uses the
[ssign PKCS11 module](https://le-syl21.github.io/ssign/pkcs11.html) with jsign.
The ssign CLI signs PE binaries and cannot directly sign `.nupkg` files.
The local `setup-ssign` action downloads ssign PKCS11 v0.1.7 and jsign 7.4,
verifies pinned SHA256 digests, and sets up Java 21. There is no SimplySign
Desktop, GUI automation, Python runtime, or signing container.

The existing release secrets map directly to the module's documented variables:

- `CERTUM_USER_ID` becomes `CERTUM_EMAIL` (the Certum account e-mail).
- `CERTUM_OTP_URI` becomes `CERTUM_OTP`; ssign accepts a full `otpauth://` URI.
- `CERTUM_CERT_FINGERPRINT` remains the expected signer SHA256 fingerprint.

The module exposes one slot, selected by SunPKCS11 `slotListIndex = 0`.
jsign uses SHA-256 with RSA PKCS#1 v1.5 and RFC3161 timestamping. Every signed
package must pass `dotnet nuget verify --all --certificate-fingerprint` before
upload. Signing secrets are scoped to the signing step. Its private runtime
directory contains ssign's shared session cache and is removed on step exit.

The BuildOnly workflow installs the same pinned tools and inspects PKCS11
mechanisms without credentials. This checks downloads and native module loading;
it does not authenticate or sign. A Release run with the protected environment's
credentials is still required to verify cloud signing end to end.

Source compatibility: [tagged ssign module](https://github.com/Le-Syl21/ssign/blob/v0.1.7/ssign-pkcs11/src/lib.rs)
explicitly supports Java/SunPKCS11 SHA256 RSA signing, including multipart data.
[jsign NuGet support](https://github.com/ebourg/jsign/blob/7.4/jsign-core/src/main/java/net/jsign/nuget/NugetFile.java)
creates NuGet `.signature.p7s` signatures. The original failed job was
[113052627313](https://github.com/ChrisPulman/CP.ReactiveUI.Primitives.Windows/actions/runs/37696509558/job/113052627313),
which timed out enumerating the desktop client's PKCS11 slots.
