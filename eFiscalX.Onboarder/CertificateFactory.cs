using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eFiscalX.Onboarder
{
    public class CertificateFactory
    {
        private ECDsa GenerateEcdsaKey()
        {
            return ECDsa.Create(ECCurve.NamedCurves.nistP256);
        }

        public (ECDsa PrivateKey, byte[] CsrBytes) CreateCertificateSigningRequest(CsrRequest model)
        {
            // 1. Generate an ECDSA P-256 private key (exportable)
            var ecdsaKey = GenerateEcdsaKey();

            // 2. Build Distinguished Name (DN)
            string dn = $"C=RKS, O={model.BusinessId}, OU={model.PosId}, L={model.BranchId}, CN={model.BusinessName}";           
            var distinguishedName = new X500DistinguishedName(dn);
            
            // 3. Create CertificateRequest with ECDSA key
            var csrRequest = new CertificateRequest(distinguishedName, ecdsaKey, HashAlgorithmName.SHA256);

            // 4. Create CSR bytes
            var csrBytes = csrRequest.CreateSigningRequest();

            // 5. Return both private key and CSR
            return (ecdsaKey, csrBytes);
        }

        public void SaveCsrToPem(string filePath, byte[] csrBytes)
        {
            string pem = ExportToPem("CERTIFICATE REQUEST", csrBytes);
            File.WriteAllText(filePath, pem);
        }
        public void SavePrivateKeyToPem(string filePath, ECDsa ecdsaKey)
        {
            var privateKeyBytes = ecdsaKey.ExportPkcs8PrivateKey();
            string pem = ExportToPem("PRIVATE KEY", privateKeyBytes);
            File.WriteAllText(filePath, pem);
        }

        private string ExportToPem(string type, byte[] data)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"-----BEGIN {type}-----");
            builder.AppendLine(Convert.ToBase64String(data, Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine($"-----END {type}-----");
            return builder.ToString();
        }
    }
}
