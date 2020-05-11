using PersonalPage.Core;
using System.Net;

namespace PersonalPage.WebApi
{
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterUserResponse response)
        {
            ContentResult.StatusCode = response.Status;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
