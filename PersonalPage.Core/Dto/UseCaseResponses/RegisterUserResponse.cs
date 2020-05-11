using System.Collections.Generic;

namespace PersonalPage.Core
{
    public class RegisterUserResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public IEnumerable<string> Errors { get; }

        public RegisterUserResponse(IEnumerable<string> errors, int status) : base(status)
        {
            Errors = errors;
        }

        public RegisterUserResponse(string id, int status) : base(status)
        {
            Id = id;
        }
    }
}
