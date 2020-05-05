namespace PersonalPage.Core
{
    public class RegisterUserRequestDto : IUseCaseRequest<RegisterUserResponse>
    {
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }

        public RegisterUserRequestDto(string userName, string email, string password)
        {
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
