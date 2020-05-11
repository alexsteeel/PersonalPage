namespace PersonalPage.Shared.Models
{
    public class FailRegisterUserResponse : RegisterUserResponse
    {
        public FailRegisterUserResponse()
        {
            Status = 400;
            Errors.Add("Registration failed.");
        }
    }
}
