using FluentValidation;
using PersonalPage.WebApi.Models.Request;

namespace PersonalPage.WebApi.Models.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.UserName).NotNull().Length(5, 20);
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull().Length(8, 15);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        }
    }
}
