using System.Linq;
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

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.UserName, message.Email), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) 
                                               : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
