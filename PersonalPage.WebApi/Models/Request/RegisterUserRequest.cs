namespace PersonalPage.WebApi.Models
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest()
        {
        }

        public RegisterUserRequest(string email, string userName, string password, string confirmPassword)
        {
            Email = email;
            UserName = userName;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
