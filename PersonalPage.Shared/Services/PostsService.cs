using Newtonsoft.Json;
using PersonalPage.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PersonalPage.Shared.Services
{
    public class PostsService
    {
        private readonly string _baseUrl;

        public PostsService(string url)
        {
            _baseUrl = url;
        }

        public string AccessToken { get; set; }

        public async Task<PostsCollectionPagingResponse> GetAllPostsByPageAsync(int page = 1)
        {
            var methodUrl = $"{_baseUrl}/api/posts?page={page}";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var response = await client.GetAsync(methodUrl);
            var jsonData = await response.Content.ReadAsStringAsync();

            var posts = JsonConvert.DeserializeObject<List<Post>>(jsonData);
            var obj = new PostsCollectionPagingResponse() { Records = posts };

            return obj;
        }

        public async Task<PostSingleResponse> GetPostByIdAsync(string id)
        {
            var methodUrl = $"{_baseUrl}/api/posts?page={id}";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var response = await client.GetAsync(methodUrl);
            var jsonData = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<PostSingleResponse>(jsonData);

            return obj;
        }

        public async Task<PostsCollectionPagingResponse> SearchPostsByPageAsync(string query, int page = 1)
        {
            var methodUrl = $"{_baseUrl}/api/posts/search?query={query}&page={page}";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var response = await client.GetAsync(methodUrl);
            var jsonData = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<PostsCollectionPagingResponse>(jsonData);

            return obj;
        }

        public async Task<PostSingleResponse> CreatePostAsync(PostRequest model)
        {
            var methodUrl = $"{_baseUrl}/api/posts";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            string jsonData = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<PostSingleResponse>(responseAsString);

            return obj;
        }

        public async Task<PostSingleResponse> EditPostAsync(PostRequest model)
        {
            var methodUrl = $"{_baseUrl}/api/posts";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            string jsonData = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(methodUrl + "/" + model.Id, content);

            var responseString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<PostSingleResponse>(responseString);

            return obj;
        }

        public async Task<PostSingleResponse> DeletePostAsync(string id)
        {
            var methodUrl = $"{_baseUrl}/api/plans/{id}";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            var response = await client.DeleteAsync(methodUrl + "/" + id);
            var jsonData = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<PostSingleResponse>(jsonData);

            return obj;
        }
    }
}