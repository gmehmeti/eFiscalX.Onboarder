using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eFiscalX.Onboarder
{
    public class TaxAuthorityClient
    {
        private readonly HttpClient _httpClient;
        private readonly bool _isProductionEnv = false;
        public TaxAuthorityClient(HttpClient httpClient, bool isProductionEnv)
        {
            _httpClient = httpClient;
            this._isProductionEnv = isProductionEnv;
        }

        #region GetVerificationCodeAsync

        public async Task<VerificationResponse> GetVerificationCodeAsync(OnboardRequest model)
        {
            string url = $"https://fiskalizimi.atk-ks.org/ca/verify/{model.NUI}";
            if (!_isProductionEnv)
            {
                url = $"https://fiskalizimi-test.atk-ks.org/ca/verify/{model.NUI}";
            }

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, model);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }

            var verificationResponse = await response.Content.ReadFromJsonAsync<VerificationResponse>();

            if (verificationResponse?.Error != null && !string.IsNullOrEmpty(verificationResponse.Error.Message))
            {
                throw new Exception($"API Error: {verificationResponse.Error.Code} - {verificationResponse.Error.Message}");
            }

            return verificationResponse;
        }

        #endregion

        #region SignCsrAsync

        public async Task<SignCsrResponse> SignCsrAsync(SignCsrRequest request)
        {
            string url = "https://fiskalizimi.atk-ks.org/ca/signcsr";

            if (!_isProductionEnv)
            {
                url = $"https://fiskalizimi-test.atk-ks.org/ca/signcsr";
            }

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"CSR signing failed with status: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }

            var result = await response.Content.ReadFromJsonAsync<SignCsrResponse>();

            if (result == null || string.IsNullOrWhiteSpace(result.SignedCertificate))
            {
                throw new Exception("CSR signing failed: Empty or invalid response.");
            }

            return result;
        } 

        #endregion
    }
}
