using Newtonsoft.Json;
using PersonalPage.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PersonalPage.Shared.Services
{
    public class CommentsService
    {
        private readonly string _baseUrl;

        public CommentsService(string url)
        {
            _baseUrl = url;
        }

        public string AccessToken { get; set; }

        public async Task<CollectionPagingResponse<Comment>> GetAllCommentsByPageAsync(int page = 1)
        {
            var methodUrl = $"{_baseUrl}/api/comments?page={page}";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var response = await client.GetAsync(methodUrl);
            var jsonData = await response.Content.ReadAsStringAsync();

            var comments = JsonConvert.DeserializeObject<List<Comment>>(jsonData);
            var obj = new CollectionPagingResponse<Comment>() { Records = comments };

            return obj;
        }

        public async Task<Comment> GetCommentByIdAsync(string id)
        {
            var methodUrl = $"{_baseUrl}/api/comments/{id}";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var response = await client.GetAsync(methodUrl);
            var jsonData = await response.Content.ReadAsStringAsync();

            var comment = JsonConvert.DeserializeObject<Comment>(jsonData);
            return comment;
        }

        public async Task<SingleResponse<Comment>> CreateCommentAsync(CommentRequest model)
        {
            var methodUrl = $"{_baseUrl}/api/comments";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            string jsonData = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(methodUrl, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<SingleResponse<Comment>>(responseAsString);

            return obj;
        }

        public async Task<Comment> EditCommentAsync(CommentRequest model)
        {
            var methodUrl = $"{_baseUrl}/api/comments";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            string jsonData = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(methodUrl + "/" + model.Id, content);

            var responseString = await response.Content.ReadAsStringAsync();

            var comment = JsonConvert.DeserializeObject<Comment>(responseString);

            return comment;
        }

        public async Task<SingleResponse<Comment>> DeleteCommentAsync(string id)
        {
            var methodUrl = $"{_baseUrl}/api/comments/{id}";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            var response = await client.DeleteAsync(methodUrl + "/" + id);
            var jsonData = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<SingleResponse<Comment>>(jsonData);

            return obj;
        }
    }
}