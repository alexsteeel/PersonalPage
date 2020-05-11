using PersonalPage.Core;
using System.Net;

namespace PersonalPage.WebApi
{
    public sealed class LoginPresenter : IOutputPort<LoginResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LoginResponse response)
        {
            ContentResult.StatusCode = response.Status;
            ContentResult.Content = response.Status == (int)HttpStatusCode.OK
                                        ? JsonSerializer.SerializeObject(response.Token)
                                        : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
