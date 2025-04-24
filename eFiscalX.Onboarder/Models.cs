using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFiscalX.Onboarder
{
    public class Onboard
    {
        [JsonProperty("fiscalization_no")]
        public string FiscalizationNo { get; set; }

        [JsonProperty("pos_id")]
        public ulong PosId { get; set; }

        [JsonProperty("branch_no")]
        public ulong BranchNo { get; set; }

        [JsonProperty("application_id")]
        public ulong ApplicationId { get; set; }
    }


    public class OnboardRespond
    {
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("verification_code")]
        public long VerificationCode { get; set; }

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

}
