using Newtonsoft.Json;
using PersonalPage.Shared.Models;
using System.Net.Http;
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
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var methodUrl  = $"{_baseUrl}/api/auth/register";
            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            UserManagerResponse obj = JsonConvert.DeserializeObject<UserManagerResponse>(responseAsString);

            return obj;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            HttpClient client = new HttpClient();

            string jsonData = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var methodUrl = $"{_baseUrl}/api/auth/login";
            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            UserManagerResponse obj = JsonConvert.DeserializeObject<UserManagerResponse>(responseAsString);

            return obj;
        }
    }
}
