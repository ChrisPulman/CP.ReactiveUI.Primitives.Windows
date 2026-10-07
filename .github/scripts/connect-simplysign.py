"""Connect the Certum GUI and prove that its PKCS#11 token is initialized.

Never print GUI contents or application logs: they can contain credentials.
Screenshots used for control recognition stay in a private temporary directory.
"""

import base64
import csv
import hashlib
import hmac
import io
import os
from pathlib import Path
import re
import shutil
import struct
import subprocess
import tempfile
import time
from urllib.parse import parse_qs, urlparse


class ConnectionFailure(Exception):
    pass


def run(*args, timeout=10):
    try:
        return subprocess.run(args, text=True, capture_output=True, timeout=timeout, check=True).stdout
    except (subprocess.SubprocessError, OSError):
        raise ConnectionFailure(f"{Path(args[0]).name} failed or timed out") from None


def windows():
    # This app has an empty WM_NAME; query its _NET_WM_NAME via getwindowname.
    try:
        ids = run("xdotool", "search", "--onlyvisible", "--name", "").split()
    except ConnectionFailure:
        return []
    found = []
    for wid in ids:
        try:
            if "implySign" in run("xdotool", "getwindowname", wid):
                found.append(wid)
        except ConnectionFailure:
            continue  # A window can close between enumeration and inspection.
    return found


def recognize(wid, directory):
    image = Path(directory) / "window.png"
    try:
        run("import", "-window", wid, str(image))
        tsv = run("tesseract", str(image), "stdout", "-l", "eng", "--psm", "11", "tsv")
        lines = {}
        for word in csv.DictReader(io.StringIO(tsv), delimiter="\t"):
            if not word["text"].strip() or float(word["conf"]) < 40:
                continue
            key = tuple(word[name] for name in ("page_num", "block_num", "par_num", "line_num"))
            lines.setdefault(key, []).append(word)
        return [
            (" ".join(word["text"] for word in words),
             min(int(word["left"]) for word in words),
             min(int(word["top"]) for word in words),
             max(int(word["left"]) + int(word["width"]) for word in words),
             max(int(word["top"]) + int(word["height"]) for word in words))
            for words in lines.values()
        ]
    finally:
        image.unlink(missing_ok=True)


def inspect_window(wid, directory):
    try:
        return recognize(wid, directory)
    except ConnectionFailure:
        if wid not in windows():
            return []  # Dialog closed while its pixels were being captured.
        raise


def match(lines, pattern):
    matches = [line for line in lines if re.fullmatch(pattern, line[0].strip(), re.IGNORECASE)]
    return matches[0] if len(matches) == 1 else None


def activate(wid):
    run("xdotool", "windowactivate", "--sync", wid)
    if run("xdotool", "getactivewindow").strip() != wid:
        raise ConnectionFailure("SimplySign window did not receive focus")


def click(wid, line):
    activate(wid)
    _, left, top, right, bottom = line
    run("xdotool", "mousemove", "--window", wid, str((left + right) // 2), str((top + bottom) // 2), "click", "1")


def fresh_otp(uri):
    try:
        parsed = urlparse(uri)
        query = parse_qs(parsed.query)
        if parsed.scheme != "otpauth" or parsed.netloc != "totp":
            raise ValueError()
        digits = int(query.get("digits", ["6"])[0])
        period = int(query.get("period", ["30"])[0])
        if not 6 <= digits <= 8 or not 20 <= period <= 120:
            raise ValueError()
        secret = query["secret"][0].upper()
        key = base64.b32decode(secret + "=" * ((8 - len(secret) % 8) % 8))
        if not key:
            raise ValueError()
        algorithm = {"SHA1": hashlib.sha1, "SHA256": hashlib.sha256, "SHA512": hashlib.sha512}[query.get("algorithm", ["SHA1"])[0].upper()]
    except (ValueError, KeyError):
        raise ConnectionFailure("CERTUM_OTP_URI is not a supported TOTP URI") from None
    # Generate only after the user field is filled. Leave enough time for typing
    # and submitting instead of submitting an OTP near the end of its period.
    remaining = period - time.time() % period
    if remaining < 15:
        time.sleep(remaining + 0.2)
    counter = int(time.time() // period)
    digest = hmac.new(key, struct.pack(">Q", counter), algorithm).digest()
    offset = digest[-1] & 15
    return str((int.from_bytes(digest[offset:offset + 4], "big") & 0x7fffffff) % (10 ** digits)).zfill(digits)


def token_slot(output):
    # Slot list index is distinct from the PKCS#11 numeric slot ID.
    for index, block in enumerate(re.split(r"(?m)^Slot \d+ .*:\s*", output)[1:]):
        if (re.search(r"token manufacturer\s*:\s*CERTUM\s*$", block, re.MULTILINE | re.IGNORECASE)
                and re.search(r"token model\s*:\s*SimplySign\b", block, re.IGNORECASE)
                and re.search(r"token flags\s*:.*\btoken initialized\b", block, re.IGNORECASE)):
            return index
    raise ConnectionFailure("PKCS#11 did not expose an initialized Certum SimplySign token")


def connect(directory):
    deadline = time.monotonic() + 90
    login = None
    while time.monotonic() < deadline:
        candidates = []
        for wid in windows():
            lines = inspect_window(wid, directory)
            email = match(lines, r"(?:E[- ]?MAIL|EMAIL)(?: ADDRESS)?[: ]*")
            code = match(lines, r"ONE[- ]TIME CODE[: ]*|TOKEN[: ]*")
            # The current Certum CAS page also has a 'Sign In' heading.
            # Only accept the submit control below the code field.
            buttons = [line for line in lines if re.fullmatch(r"SIGN IN|LOG\s*(?:IN|ON)|LOGIN", line[0], re.IGNORECASE)
                       and code and line[2] > code[4]]
            if email and code and len(buttons) == 1:
                candidates.append((wid, email, code, buttons[0]))
        if len(candidates) == 1:
            login = candidates[0]
            break
        time.sleep(2)
    if login is None:
        raise ConnectionFailure("SimplySign login form was not recognized within 90 seconds")
    wid, email, code, button = login
    print("SimplySign login form recognized", flush=True)
    click(wid, email)
    run("xdotool", "key", "--clearmodifiers", "ctrl+a")
    run("xdotool", "type", "--clearmodifiers", "--delay", "25", "--", os.environ["CERTUM_USER_ID"])
    # Certum's HTML labels explicitly target username/password. Clicking the
    # code label avoids dependence on checkbox and link keyboard tab order.
    click(wid, code)
    run("xdotool", "key", "--clearmodifiers", "ctrl+a")
    otp = fresh_otp(os.environ["CERTUM_OTP_URI"])
    print(f"::add-mask::{otp}", flush=True)
    activate(wid)
    run("xdotool", "type", "--clearmodifiers", "--delay", "25", "--", otp)
    click(wid, button)
    deadline = time.monotonic() + 90
    while time.monotonic() < deadline:
        for current in windows():
            lines = inspect_window(current, directory)
            # The vendor's 2.9.15 English strings.plist spells it 'succesfull'.
            if any(re.search(r"(?:logon|login|log in)\s+(?:successful|succesfull)", line[0], re.IGNORECASE) for line in lines):
                close = match(lines, r"CLOSE")
                if close:
                    click(current, close)
                    # The token is unavailable until this success dialog closes.
                    for _ in range(10):
                        time.sleep(0.5)
                        if current not in windows() or not match(inspect_window(current, directory), r"CLOSE"):
                            print("SimplySign success dialog closed", flush=True)
                            return
                    raise ConnectionFailure("SimplySign success dialog did not close")
            if any(re.search(r"(?:invalid|incorrect|failed|error|expired)", line[0], re.IGNORECASE) for line in lines):
                raise ConnectionFailure("SimplySign reported a login error (GUI content withheld)")
        time.sleep(2)
    raise ConnectionFailure("SimplySign did not confirm a successful login within 90 seconds")


def main():
    os.umask(0o077)
    for name in ("CERTUM_USER_ID", "CERTUM_OTP_URI", "SS_DIST", "SS_EXE", "SS_PKCS11", "RUNNER_TEMP", "GITHUB_ENV"):
        if not os.environ.get(name):
            raise ConnectionFailure(f"Required environment variable {name} is missing")
    for name in ("SS_EXE", "SS_PKCS11"):
        if not Path(os.environ[name]).is_file():
            raise ConnectionFailure(f"Resolved {name} file is missing")
    home = Path.home()
    shutil.copyfile(Path(os.environ["SS_DIST"]) / "SimplySignDesktop.xml", home / "SimplySignDesktop.xml")
    (home / ".config").mkdir(exist_ok=True)
    (home / ".config" / "Unknown Organization.conf").write_text("[General]\nCacheUserIdAtLogon=Yes\nShowLogonDialogAfterApplicationStartup=Yes\nShowLogonDialogWhenAnyAppRequestsAccess=Yes\n")
    os.environ.setdefault("USER", "root")
    os.environ["LANG"] = "C.UTF-8"
    os.environ["LC_ALL"] = "C.UTF-8"
    os.environ["LD_LIBRARY_PATH"] = os.environ["SS_DIST"] + ":" + os.environ.get("LD_LIBRARY_PATH", "")
    # Do not emit the application's log: it may include user identifiers.
    with tempfile.TemporaryDirectory(prefix="simplysign-", dir=os.environ["RUNNER_TEMP"]) as directory:
        with open(Path(directory) / "application.log", "w") as log:
            subprocess.Popen([os.environ.get("SS_START") or os.environ["SS_EXE"]], stdout=log, stderr=log, start_new_session=True)
            connect(directory)
            # The session can take a few seconds to populate after Close. Bound
            # both each probe and the number of probes; never sign on exit 0
            # alone, since an empty slot list also exits successfully.
            for attempt in range(3):
                try:
                    output = run("pkcs11-tool", "--module", os.environ["SS_PKCS11"], "-L", timeout=10)
                    slot = token_slot(output)
                    break
                except ConnectionFailure:
                    if attempt == 2:
                        raise ConnectionFailure("SimplySign token readiness failed after three bounded probes") from None
                    time.sleep(2)
            with open(os.environ["GITHUB_ENV"], "a") as env:
                env.write(f"SS_SLOT_INDEX={slot}\n")
            print(f"Initialized Certum SimplySign token verified (slot list index {slot})")


if __name__ == "__main__":
    try:
        main()
    except (ConnectionFailure, OSError):
        # Only our own controlled messages reach the CI log. OS errors can carry
        # command arguments or filenames containing credential-derived data.
        import sys
        error = sys.exc_info()[1]
        print(f"::error::{error if isinstance(error, ConnectionFailure) else 'SimplySign runtime setup failed'}")
        raise SystemExit(1)
