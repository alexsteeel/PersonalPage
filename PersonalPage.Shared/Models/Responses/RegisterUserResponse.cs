using Newtonsoft.Json;

namespace PersonalPage.Shared.Models
{
    public class RegisterUserResponse
    {
        [JsonProperty("errors")]
        public RegisterUserErrors Errors { get; set; } = new RegisterUserErrors();

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get => Status == 200; }

        [JsonIgnore]
        public string Message { get => Errors.Message; }
    }
}