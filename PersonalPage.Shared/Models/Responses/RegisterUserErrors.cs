using Newtonsoft.Json;
using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class RegisterUserErrors
    {
        [JsonProperty("Email")]
        public IList<string> Email { get; set; } = new List<string>();

        [JsonProperty("UserName")]
        public IList<string> UserName { get; set; } = new List<string>();

        [JsonProperty("Password")]
        public IList<string> Password { get; set; } = new List<string>();

        [JsonIgnore]
        public string Message { get => (string.Join(" ", Email) + " " 
                + string.Join(" ", UserName) + " " + string.Join(" ", Password)).Replace("  ", " ").Trim(); }
    }
}
