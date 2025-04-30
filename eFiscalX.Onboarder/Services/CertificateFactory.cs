using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eFiscalX.Onboarder.Services
{
    public class CertificateFactory
    {
        private string certificatesFolder = "";
        public CertificateFactory()
        {
            certificatesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificates");
        }

        private ECDsa GenerateEcdsaKey()
        {
            return ECDsa.Create(ECCurve.NamedCurves.nistP256);
        }

        public (string PrivateKeyPem, string CsrPem) CreateCertificateSigningRequest(CsrRequest model)
        {
            // 1. Generate an ECDSA P-256 private key (exportable)
            var ecdsaKey = GenerateEcdsaKey();

            // 2. Build Distinguished Name (DN)
            string dn = $"C=RKS, O={model.BusinessId}, OU={model.PosId}, L={model.BranchId}, CN={model.BusinessName}";           
            var subjectName = new X500DistinguishedName(dn);
            
            // 3. Create CertificateRequest with ECDSA key
            var csrRequest = new CertificateRequest(subjectName, ecdsaKey, HashAlgorithmName.SHA256);

            // 4. Create CSR PEM
            var csrPem = csrRequest.CreateSigningRequestPem();

            // 5: Save CSR and Private Key
            var privateKeyPem = SavePrivateKeyToPem($"{model.BusinessId}_private_key.pem", ecdsaKey);
            SaveCsrToPem($"{model.BusinessId}_csr.pem", csrPem);

            // 6. Return both private key and CSR
            return (privateKeyPem, csrPem);
        }

        private void SaveCsrToPem(string filePath, string csrPem)
        {
            var fileName = Path.Combine(certificatesFolder, filePath);
            File.WriteAllText(fileName, csrPem);
        }

        private string SavePrivateKeyToPem(string filePath, ECDsa ecdsaKey)
        {
            string privateKeyPem = ecdsaKey.ExportECPrivateKeyPem();
            var fileName = Path.Combine(certificatesFolder, filePath);
            File.WriteAllText(fileName, privateKeyPem);
            return privateKeyPem;
        }

        public void SaveSignedCertificate(string filePath, string signedCert)
        {
            var fileName = Path.Combine(certificatesFolder, filePath);
            File.WriteAllText(fileName, signedCert);
        }

        public void SaveSignedCertificatePfx(string filePath, string privateKeyPem, string signedCertPem)
        {
            // Load Private Key
            ECDsa privateKey = LoadPrivateKeyFromPem(privateKeyPem);

            // Load Signed Certificate
            var certificate = LoadCertificateFromPem(signedCertPem);

            // Attach Private Key to Certificate
            var certWithKey = certificate.CopyWithPrivateKey(privateKey);

            // Export to PFX
            string pfxPassword = "StrongPassword1!"; //Always use a STRONG PASSWORD when exporting a PFX

            byte[] pfxBytes = certWithKey.Export(X509ContentType.Pfx, pfxPassword);

            // Save to file
            var fileName = Path.Combine(certificatesFolder, filePath);
            File.WriteAllBytes(fileName, pfxBytes);
        }

        private ECDsa LoadPrivateKeyFromPem(string privateKeyPem)
        {
            string base64 = ExtractPemContent(privateKeyPem, "EC PRIVATE KEY");
            byte[] keyBytes = Convert.FromBase64String(base64);

            ECDsa ecdsa = ECDsa.Create();
            ecdsa.ImportECPrivateKey(keyBytes, out _);
            return ecdsa;
        }

        private X509Certificate2 LoadCertificateFromPem(string signedCertPem)
        {
            string base64 = ExtractPemContent(signedCertPem, "CERTIFICATE");
            byte[] certBytes = Convert.FromBase64String(base64);

            return new X509Certificate2(certBytes);
        }

        private string ExtractPemContent(string pem, string section)
        {
            string header = $"-----BEGIN {section}-----";
            string footer = $"-----END {section}-----";

            int start = pem.IndexOf(header) + header.Length;
            int end = pem.IndexOf(footer, start);

            string base64 = pem.Substring(start, end - start);
            return base64.Replace("\r", "").Replace("\n", "").Trim();
        }
    }
}
