using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PersonalPage.Core;
using PersonalPage.WebApi.Controllers;
using PersonalPage.WebApi.Models.Request;
using System.Net;
using System.Threading.Tasks;

namespace PersonalPage.WebApi.UnitTests
{
    [TestFixture]
    public class AccountsControllerUnitTests
    {
        [Test]
        public async Task Post_UseCaseSucceeds_ReturnsOk()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new CreateUserResponse("", true)));

            // fakes
            var outputPort = new RegisterUserPresenter();
            var useCase = new RegisterUserUseCase(mockUserRepository.Object);

            var controller = new AccountsController(useCase, outputPort);

            // act
            var result = await controller.Post(new RegisterUserRequest());

            // assert
            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }

        [Test]
        public async Task Post_ModelValidationFails_ReturnsError()
        {
            // arrange
            var controller = new AccountsController(null, null);
            controller.ModelState.AddModelError("UserName", "Required");

            // act
            var result = await controller.Post(null);

            // assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.IsInstanceOf<SerializableError>((result as BadRequestObjectResult).Value);
        }
    }
}