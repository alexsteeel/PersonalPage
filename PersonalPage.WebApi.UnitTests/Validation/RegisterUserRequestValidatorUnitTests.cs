using FluentValidation.TestHelper;
using NUnit.Framework;
using PersonalPage.WebApi.Models.Request;
using PersonalPage.WebApi.Models.Validation;

namespace PersonalPage.WebApi.UnitTests.Validation
{

    [TestFixture]
    public class RegisterUserRequestValidatorUnitTests
    {
        private RegisterUserRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new RegisterUserRequestValidator();
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

        [TestCase("11@test.ru")]
        [TestCase("fsadfgasdfsafs@wertwqe.com")]
        public void Validate_CorrectEmail_IsValid(string email)
        {
            validator.ShouldNotHaveValidationErrorFor(req => req.Email, email);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("s")]
        [TestCase("12321@12343")]
        [TestCase("@12343.re")]
        public void Validate_IncorrectEmail_IsNotValid(string email)
        {
            validator.ShouldHaveValidationErrorFor(req => req.Email, email);
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

        [TestCase("12345678", "12345678")]
        [TestCase("gsdfgw4r5t62353", "gsdfgw4r5t62353")]
        public void Validate_CorrectConfirmPassword_IsValid(string password, string confirmPassword)
        {
            var userRequest = new RegisterUserRequest
            {
                Password = password,
                ConfirmPassword = confirmPassword
            };
            validator.ShouldNotHaveValidationErrorFor(req => req.ConfirmPassword, userRequest);
        }

        [TestCase("4234234", "")]
        [TestCase("12345678", "123456789")]
        public void Validate_IncorrectConfirmPassword_IsNotValid(string password, string confirmPassword)
        {
            var userRequest = new RegisterUserRequest 
            {
                Password = password, 
                ConfirmPassword = confirmPassword 
            };
            validator.ShouldHaveValidationErrorFor(req => req.ConfirmPassword, userRequest);
        }
    }
}
