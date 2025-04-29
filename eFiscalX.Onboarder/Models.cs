using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFiscalX.Onboarder
{
    public class OnboardRequest
    {
        [JsonIgnore]
        public ulong NUI { get; set; }

        [JsonProperty("fiscalization_no")]
        public string FiscalizationNo { get; set; }

        [JsonProperty("pos_id")]
        public ulong PosId { get; set; }

        [JsonProperty("branch_id")]
        public ulong BranchId { get; set; }

        [JsonProperty("application_id")]
        public ulong ApplicationId { get; set; }
    }


    public class VerificationResponse
    {
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("verification_code")]
        public ulong VerificationCode { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SignCsrRequest
    {
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("business_id")]
        public ulong BusinessId { get; set; }

        [JsonProperty("branch_id")]
        public ulong BranchId { get; set; }

        [JsonProperty("verification_no")]
        public ulong VerificationNo { get; set; }

        [JsonProperty("pos_id")]
        public ulong PosId { get; set; }

        [JsonProperty("application_id")]
        public ulong ApplicationId { get; set; }

        [JsonProperty("csr")]
        public string Csr { get; set; } // This should be PEM string
    }

    public class SignCsrResponse
    {
        [JsonProperty("signed_certificate")]
        public string SignedCertificate { get; set; }
    }

    public class CsrRequest
    {
        public string Country { get; set; } = "RKS";
        public string BusinessName { get; set; }
        public ulong BusinessId { get; set; }
        public ulong BranchId { get; set; }
        public ulong PosId { get; set; }
    }
}
