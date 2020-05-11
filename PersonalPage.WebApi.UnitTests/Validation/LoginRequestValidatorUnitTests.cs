using FluentValidation.TestHelper;
using NUnit.Framework;
using PersonalPage.WebApi.Models;

namespace PersonalPage.WebApi.UnitTests.Validation
{
    [TestFixture]
    public class LoginRequestValidatorUnitTests
    {
        private LoginRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new LoginRequestValidator();
        }

        [TestCase("sssss")]
        [TestCase("gfdsgsdfgsd")]
        [TestCase("ssssssssssssssssssss")]
        public void Validate_CorrectUserName_IsValid(string userName)
        {
            validator.ShouldNotHaveValidationErrorFor(req => req.UserName, userName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("s")]
        [TestCase("ssss")]
        [TestCase("sssssssssssssssssssss")]
        public void Validate_IncorrectUserName_IsNotValid(string userName)
        {
            validator.ShouldHaveValidationErrorFor(req => req.UserName, userName);
        }

        [TestCase("12345678")]
        [TestCase("gsdfgw4r5t62353")]
        public void Validate_CorrectPassword_IsValid(string password)
        {
            validator.ShouldNotHaveValidationErrorFor(req => req.Password, password);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("s")]
        [TestCase("1234567")]
        [TestCase("1234567890123456")]
        public void Validate_IncorrectPassword_IsNotValid(string password)
        {
            validator.ShouldHaveValidationErrorFor(req => req.Password, password);
        }
    }
}
