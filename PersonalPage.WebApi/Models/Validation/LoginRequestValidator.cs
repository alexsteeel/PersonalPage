using FluentValidation;

namespace PersonalPage.WebApi.Models
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotNull().Length(5, 20);
            RuleFor(x => x.Password).NotNull().Length(8, 15);
        }
    }
}
