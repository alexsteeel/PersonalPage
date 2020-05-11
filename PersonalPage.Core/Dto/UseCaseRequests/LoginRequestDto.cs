namespace PersonalPage.Core
{
    public class LoginRequestDto : IUseCaseRequest<LoginResponse>
    {
        public LoginRequestDto(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}