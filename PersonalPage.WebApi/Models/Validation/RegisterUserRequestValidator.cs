using FluentValidation;
using PersonalPage.WebApi.Models.Request;

namespace PersonalPage.WebApi.Models.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.UserName).Length(5, 255);
            RuleFor(x => x.Password).Length(6, 15);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        }
    }
}
