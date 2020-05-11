using Newtonsoft.Json;
using NUnit.Framework;
using PersonalPage.Core;
using System.Collections.Generic;
using System.Net;

namespace PersonalPage.WebApi.UnitTests
{
    public class RegisterUserPresenterUnitTests
    {
        [Test]
        public void Handle_UseCaseSucceeds_ReturnId()
        {
            var presenter = new RegisterUserPresenter();

            presenter.Handle(new RegisterUserResponse("1234", (int)HttpStatusCode.OK));

            Assert.AreEqual((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);            
            Assert.AreEqual(data.status.Value, (int)HttpStatusCode.OK);
            Assert.AreEqual("1234", data.id.Value);
        }

        [Test]
        public void Handle_UseCaseFail_ReturnErrors()
        {
            var presenter = new RegisterUserPresenter();
            var errorMessage = "Missing user name.";

            presenter.Handle(new RegisterUserResponse(new List<string>() { errorMessage }, (int)HttpStatusCode.BadRequest));

            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.AreEqual(data.status.Value, (int)HttpStatusCode.BadRequest);
            Assert.AreEqual(errorMessage, data.errors.First.Value);
        }
    }
}