using Microsoft.AspNetCore.Mvc;
using PersonalPage.Core;
using PersonalPage.WebApi.Models;
using System.Threading.Tasks;

namespace PersonalPage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;

        public LoginController(ILoginUseCase loginUseCase, LoginPresenter loginPresenter)
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
        }

        // POST api/login
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            await _loginUseCase.Handle(new LoginRequestDto(request.UserName, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }
    }
}
