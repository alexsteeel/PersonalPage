using System.Collections.Generic;

namespace PersonalPage.Core
{
    public sealed class CreateUserResponse : BaseGatewayResponse
    {
        public string Id { get; }

        public CreateUserResponse(string id, bool success = false, IEnumerable<string> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
