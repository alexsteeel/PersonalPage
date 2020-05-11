using System.Collections.Generic;

namespace PersonalPage.Core
{
    public class LoginResponse : UseCaseResponseMessage
    {
        public Token Token { get; }
        public IEnumerable<string> Errors { get; }

        public LoginResponse(IEnumerable<string> errors, int status) : base(status)
        {
            Errors = errors;
        }

        public LoginResponse(Token token, int status) : base(status)
        {
            Token = token;
        }
    }
}
