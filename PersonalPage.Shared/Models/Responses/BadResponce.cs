using Newtonsoft.Json;

namespace PersonalPage.Shared.Models
{
    public class BadResponce
    {
        [JsonProperty("errors")]
        public Error[] Errors { get; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }
    }
}
