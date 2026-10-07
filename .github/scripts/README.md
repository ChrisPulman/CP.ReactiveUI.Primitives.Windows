The release signing workflow uses `connect-simplysign.py` inside the Certum
signer container. ImageMagick and Tesseract recognize the English login labels
and success dialog; no credentials, application logs, OCR text, or screenshots
are published. An unrecognized form fails closed.

The previous workflow identified a window by size, clicked fixed percentages,
and clicked Close after eight seconds without establishing login success.
Job [113052627313](https://github.com/ChrisPulman/CP.ReactiveUI.Primitives.Windows/actions/runs/37696509558/job/113052627313)
found a 672x510 window, then timed out enumerating PKCS#11 slots. Its logs do not
establish which login control received the clicks.

Source evidence for the replacement:

- The [Certum CAS login page](https://cloudsign.webnotarius.pl/idp/login),
  inspected on 2026-10-07, labels its inputs `E-mail` and `One-time code` with
  `for="username"` and `for="password"`. It has both a `Sign In` heading and a
  submit button below the code field. Clicking the associated labels focuses
  the inputs and avoids dependence on page proportions or tab order.
- The vendor installer version
  [2.9.15-9.4.5.0](https://files.certum.eu/software/SimplySignDesktop/Linux-Ubuntu/2.9.15-9.4.5.0/SimplySignDesktop-2.9.15-9.4.5.0-x86_64-prod-ubuntu.bin)
  used by the signer image contains `languages/en/strings.plist`: its success
  message is literally `Logon succesfull`, and its dismissal control is `Close`.
- The container reference [documents that slot enumeration hangs](https://github.com/hpvb/certum-container#troubleshooting)
  when login is incomplete or the success dialog remains open. The
  [shared signing action](https://github.com/reactiveui/actions-common/blob/main/.github/actions/certum-sign/action.yml)
  uses the same login and Close sequence as the previous workflow.

The script waits for recognized controls, generates a fresh OTP immediately
before submission, closes only a recognized success dialog, and requires an
initialized token with manufacturer `CERTUM` and model `SimplySign`. It exports
the actual slot list index used by jsign. Three bounded readiness probes handle
session initialization; package certificate verification remains mandatory.
