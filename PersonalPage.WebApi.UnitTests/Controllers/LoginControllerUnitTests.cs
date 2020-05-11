using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PersonalPage.Core;
using PersonalPage.WebApi.Controllers;
using PersonalPage.WebApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace PersonalPage.WebApi.UnitTests
{
    [TestFixture]
    public class LoginControllerUnitTests
    {
        [Test]
        public async Task Login_UseCaseSucceeds_ReturnsOk()
        {
            var user = new User("username", "123");
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(user));
            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();           

            // fakes
            var outputPort = new LoginPresenter();
            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var controller = new LoginController(useCase, outputPort);

            // act
            var result = await controller.Login(new LoginRequest(user.UserName, "1234"));

            // assert
            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }

        [TestCase(null, null)]
        public async Task Login_DbFails_ReturnsError(string username, string password)
        {
            var user = new User(username, "123");
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(user));
            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            var errorMessage = "Invalid username or password";

            var mockJwtFactory = new Mock<IJwtFactory>();

            // fakes
            var outputPort = new LoginPresenter();
            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var controller = new LoginController(useCase, outputPort);

            // act
            var result = await controller.Login(new LoginRequest(user.UserName, password));

            // assert
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, ((JsonContentResult)result).StatusCode);
            Assert.IsTrue(((JsonContentResult)result).Content.Contains(errorMessage));
        }
    }
}