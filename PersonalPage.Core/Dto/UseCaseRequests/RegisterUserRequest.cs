using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPage.Core
{
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }

        public RegisterUserRequest(string userName, string email, string password)
        {
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
