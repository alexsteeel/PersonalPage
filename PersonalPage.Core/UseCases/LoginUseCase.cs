using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PersonalPage.Core
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> Handle(LoginRequestDto message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.UserName) && !string.IsNullOrEmpty(message.Password))
            {
                var user = await _userRepository.FindByName(message.UserName);
                if (user != null)
                {
                    if (await _userRepository.CheckPassword(user, message.Password))
                    {
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName), (int)HttpStatusCode.OK));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new List<string>() { "login_failure", "Invalid username or password." },
                                                (int)HttpStatusCode.Unauthorized));
            return false;
        }
    }
}
