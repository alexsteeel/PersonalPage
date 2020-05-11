using Newtonsoft.Json;

namespace PersonalPage.Shared.Models
{
    public class Token
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("authToken")]
        public string AuthToken { get; set; }

        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }
    }
}
