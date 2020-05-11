using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPage.Core
{
    public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequestDto, LoginResponse>
    {
    }
}
