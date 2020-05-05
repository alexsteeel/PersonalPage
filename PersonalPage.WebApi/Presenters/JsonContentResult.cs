using Microsoft.AspNetCore.Mvc;

namespace PersonalPage.WebApi
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
