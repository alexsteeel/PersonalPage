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

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            HttpClient client = new HttpClient();

            string jsonData = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var methodUrl  = $"{_baseUrl}/api/register";
            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            var res = new UserManagerResponse();            
            try
            {
                res = JsonConvert.DeserializeObject<UserManagerResponse>(responseAsString);
            }
            catch (Exception)
            {
                var badResponce = JsonConvert.DeserializeObject<BadResponce>(responseAsString);
                Debug.WriteLine(badResponce.Errors.First().fieldName);
                res.IsSuccess = false;
                res.Message = $"{string.Join(" ", badResponce.Errors.Select(x => x.messageList))}";
            }

            return res;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            HttpClient client = new HttpClient();

            string jsonData = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var methodUrl = $"{_baseUrl}/api/auth/login";
            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            UserManagerResponse obj = JsonConvert.DeserializeObject<UserManagerResponse>(responseAsString);

            return obj;
        }
    }
}
