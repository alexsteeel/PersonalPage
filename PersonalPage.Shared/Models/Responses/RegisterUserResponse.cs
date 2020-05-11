using Newtonsoft.Json;
using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class RegisterUserResponse
    {
        [JsonProperty("errors")]
        public List<string> Errors { get; set; } = new List<string>();

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get => Status == 200; }

        [JsonIgnore]
        public string Message { get => Errors.Count == 0 && IsSuccess
                                            ? "Registration successful."
                                            : string.Join(" ", Errors); }
    }
}