using Newtonsoft.Json;
using PersonalPage.Shared.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PersonalPage.Shared.Services
{
    public class AuthenticationService
    {
        private readonly string _baseUrl;

        public AuthenticationService(string url)
        {
            _baseUrl = url;
        }

        public async Task<RegisterUserResponse> RegisterUserAsync(RegisterRequest request)
        {
            string responseAsString = await GetRegisterResponceString(request);

            RegisterUserResponse res = ConvertToRegisterResponce(responseAsString);

            return res;
        }

        public RegisterUserResponse ConvertToRegisterResponce(string responseAsString)
        {
            RegisterUserResponse res;
            try
            {
                res = JsonConvert.DeserializeObject<RegisterUserResponse>(responseAsString) ?? new FailRegisterUserResponse();
                if (!res.IsSuccess && string.IsNullOrWhiteSpace(res.Message))
                {
                    res = new FailRegisterUserResponse();
                }
            }
            catch (Exception)
            {
                res = new FailRegisterUserResponse();
            }
            return res;
        }

        private async Task<string> GetRegisterResponceString(RegisterRequest request)
        {
            HttpClient client = new HttpClient();

            string jsonData = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var methodUrl = $"{_baseUrl}/api/register";
            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<RegisterUserResponse> LoginUserAsync(LoginRequest request)
        {
            HttpClient client = new HttpClient();

            string jsonData = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var methodUrl = $"{_baseUrl}/api/auth/login";
            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            RegisterUserResponse obj = JsonConvert.DeserializeObject<RegisterUserResponse>(responseAsString);

            return obj;
        }
    }
}
