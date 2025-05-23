﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eFiscalX.Onboarder.Services
{
    public class TaxAuthorityClient
    {
        private readonly HttpClient _httpClient;
        private readonly bool _isProductionEnv = false;
        public TaxAuthorityClient(HttpClient httpClient, bool isProductionEnv)
        {
            _httpClient = httpClient;
            _isProductionEnv = isProductionEnv;
        }

        #region GetVerificationCodeAsync

        public async Task<VerificationResponse> GetVerificationCodeAsync(OnboardRequest model)
        {
            string url = $"https://fiskalizimi.atk-ks.org/ca/verify/{model.NUI}";
            if (!_isProductionEnv)
            {
                url = $"https://fiskalizimi-test.atk-ks.org/ca/verify/{model.NUI}";
            }

            string jsonBody = JsonConvert.SerializeObject(model, Formatting.Indented);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            var verificationResponse = JsonConvert.DeserializeObject<VerificationResponse>(responseBody);

            if (verificationResponse?.Error != null && !string.IsNullOrEmpty(verificationResponse.Error.Message))
            {
                throw new Exception($"API Error: {verificationResponse.Error.Code} - {verificationResponse.Error.Message}");
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }

            return verificationResponse;
        }

        #endregion

        #region SignCsrAsync

        public async Task<SignCsrResponse> SignCsrAsync(SignCsrRequest requestModel)
        {
            string url = "https://fiskalizimi.atk-ks.org/ca/signcsr";
            if (!_isProductionEnv)
            {
                url = $"https://fiskalizimi-test.atk-ks.org/ca/signcsr";
            }

            string jsonBody = JsonConvert.SerializeObject(requestModel, Formatting.Indented);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignCsrResponse>(responseBody);

            if (result?.Error != null && !string.IsNullOrEmpty(result.Error))
            {
                throw new Exception($"API Error: {result.Error}");
            }

            if (result == null || string.IsNullOrWhiteSpace(result.SignedCertificate))
            {
                result.Error += $"\"CSR signing failed: Empty or invalid response.";
                throw new Exception("CSR signing failed: Empty or invalid response.");
            }

            if (!response.IsSuccessStatusCode)
            {
                result.Error += $"\nCSR signing failed with status: {response.StatusCode}, Reason: {response.ReasonPhrase}";
                throw new HttpRequestException($"CSR signing failed with status: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }

            return result;
        } 

        #endregion
    }
}
