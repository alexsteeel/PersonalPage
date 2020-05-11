using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PersonalPage.Core
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequestDto message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.UserName, message.Email), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, (int)HttpStatusCode.OK) 
                                               : new RegisterUserResponse(response.Errors, (int)HttpStatusCode.BadRequest));
            return response.Success;
        }
    }
}
