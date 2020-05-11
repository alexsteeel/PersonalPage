using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace PersonalPage.Shared.Models
{
    public class LoginResponse
    {
        [JsonProperty("errors")]
        public List<string> Errors { get; set; } = new List<string>();

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("token")]
        public Token Token { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get => Status == (int)HttpStatusCode.OK; }

        [JsonIgnore]
        public string Message { get => Errors.Count == 0 && IsSuccess
                                            ? "Registration successful."
                                            : string.Join(" ", Errors); }

    }
}