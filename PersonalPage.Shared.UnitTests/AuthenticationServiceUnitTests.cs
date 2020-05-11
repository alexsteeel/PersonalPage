using NUnit.Framework;
using PersonalPage.Shared.Models;
using PersonalPage.Shared.Services;
using System.Linq;

namespace PersonalPage.Shared.UnitTests
{
    public class AuthenticationServiceUnitTests
    {
        [SetUp]
        public void Setup()
        {
            AuthenticationService = new AuthenticationService(string.Empty);
        }

        public AuthenticationService AuthenticationService { get; set; }

        [TestCase("")]
        [TestCase(@"{""title"":""One or more validation errors occurred."",""status"":400}")]
        [TestCase(@"{""errors"":{}, ""title"":""One or more validation errors occurred."",""status"":400}")]
        [TestCase(@"{""errors"":{""Password"":[""', ""title"":""One or more validation errors occurred."",""status"":400}")]
        public void ConvertToRegisterResponce_IncorrectErrors_ReturnNotSuccess(string responseAsString)
        {
            var responce = AuthenticationService.ConvertToRegisterResponce(responseAsString);

            Assert.IsInstanceOf<FailRegisterUserResponse>(responce);
            Assert.IsFalse(responce.IsSuccess);
            Assert.AreEqual("Registration failed.", responce.Message);
        }

        [TestCase("{\"errors\": { \"Password\": [\"Incorrect password.\"] }, \"title\": \"One or more validation errors occurred.\", \"status\": 400 }")]
        public void ConvertToRegisterResponce_HasError_ReturnNotSuccess(string responseAsString)
        {
            var responce = AuthenticationService.ConvertToRegisterResponce(responseAsString);

            Assert.IsInstanceOf<RegisterUserResponse>(responce);
            Assert.IsFalse(responce.IsSuccess);
            Assert.AreEqual("Incorrect password.", responce.Message);
        }

        [TestCase("{\"errors\": {\"Email\": [ \"Incorrect email.\"], \"Password\": [\"Incorrect password.\"] }, \"title\": \"One or more validation errors occurred.\", \"status\": 400 }")]
        public void ConvertToRegisterResponce_HasErrors_ReturnNotSuccess(string responseAsString)
        {
            var responce = AuthenticationService.ConvertToRegisterResponce(responseAsString);

            Assert.IsInstanceOf<RegisterUserResponse>(responce);
            Assert.IsFalse(responce.IsSuccess);
            Assert.AreEqual("Incorrect email. Incorrect password.", responce.Message);
        }

        [TestCase("{\"errors\": { \"Password\": [\"Incorrect password.\", \"Second message.\"] }, \"title\": \"One or more validation errors occurred.\", \"status\": 400 }")]
        public void ConvertToRegisterResponce_HasTwoErrorMsgs_ReturnNotSuccess(string responseAsString)
        {
            var responce = AuthenticationService.ConvertToRegisterResponce(responseAsString);

            Assert.IsInstanceOf<RegisterUserResponse>(responce);
            Assert.IsFalse(responce.IsSuccess);
            Assert.AreEqual("Incorrect password. Second message.", responce.Message);
        }
    }
}