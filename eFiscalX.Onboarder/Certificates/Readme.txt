# Certificates Folder

This folder contains all generated cryptographic materials related to the Fiscalization Service onboarding process.

Files included:
- **Private Key (.pem)**: The ECDSA P-256 private key used for signing requests and generating the CSR. 
- **Certificate Signing Request (CSR) (.pem)**: The CSR generated using the private key and business details, used to request a signed certificate.
- **Signed Certificate (.pem)**: The certificate signed and returned by the Fiscalization Service, in PEM format.
- **Signed Certificate (.pfx)**: The signed certificate combined with the private key, packaged into a password-protected PFX file for secure usage.

> ⚠ **Important:**  
> - The private key must remain confidential and must not be shared or moved outside this machine.
> - Backup the PFX file securely with password protection.