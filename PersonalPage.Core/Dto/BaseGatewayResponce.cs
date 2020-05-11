using System.Collections.Generic;

namespace PersonalPage.Core
{
    public abstract class BaseGatewayResponse
    {
        public bool Success { get; }
        public IEnumerable<string> Errors { get; }

        protected BaseGatewayResponse(bool success = false, IEnumerable<string> errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }
}
