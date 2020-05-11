using Newtonsoft.Json;
using NUnit.Framework;
using PersonalPage.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PersonalPage.WebApi.UnitTests.Presenters
{
    public class LoginPresenterUnitTests
    {
        [Test]
        public void Handle_UseCaseSucceeds_ReturnToken()
        {
            const string authToken = "777888AAABBB";
            var presenter = new LoginPresenter();

            presenter.Handle(new LoginResponse(new Token("1", authToken, 0), (int)HttpStatusCode.OK));

            Assert.AreEqual((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.AreEqual(authToken, data.authToken.Value);
        }

        [Test]
        public void Handle_UseCaseFails_ReturnError()
        {
            var presenter = new LoginPresenter();
            var errorMessage = "Invalid username/password";

            presenter.Handle(new LoginResponse(new List<string>() { errorMessage }, (int)HttpStatusCode.Unauthorized));

            var data = JsonConvert.DeserializeObject<IEnumerable<string>>(presenter.ContentResult.Content);
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, presenter.ContentResult.StatusCode);
            Assert.AreEqual(errorMessage, data.First());
        }
    }
}
