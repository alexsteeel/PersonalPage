using Newtonsoft.Json;
using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class Author
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("posts")]
        public IList<object> Posts { get; set; }
    }
}
