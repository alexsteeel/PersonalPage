using Microsoft.AspNetCore.Mvc;
using PersonalPage.Core;
using PersonalPage.WebApi.Models;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PersonalPage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;

        public RegisterController(IRegisterUserUseCase registerUserUseCase, RegisterUserPresenter registerUserPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
        }

        // POST api/register
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserRequest request)
        {
            await _registerUserUseCase.Handle(new RegisterUserRequestDto(request.UserName, request.Email, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}