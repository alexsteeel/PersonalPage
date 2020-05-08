using Newtonsoft.Json;

namespace PersonalPage.Shared.Models
{
    public sealed class Error
    {
        public string fieldName = "";
        public string[] messageList = null;
    }
}
