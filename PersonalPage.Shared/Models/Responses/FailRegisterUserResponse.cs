namespace PersonalPage.Shared.Models
{
    public class FailRegisterUserResponse : RegisterUserResponse
    {
        public FailRegisterUserResponse()
        {
            Status = 400;
            Errors.UserName.Add("Registration failed.");
        }
    }
}
