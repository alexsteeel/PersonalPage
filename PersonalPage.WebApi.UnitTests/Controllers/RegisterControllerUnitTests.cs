using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PersonalPage.Core;
using PersonalPage.WebApi.Controllers;
using PersonalPage.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PersonalPage.WebApi.UnitTests
{
    [TestFixture]
    public class RegisterControllerUnitTests
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

            var controller = new RegisterController(useCase, outputPort);

            // act
            var result = await controller.Post(new RegisterUserRequest());

            // assert
            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }

        [Test]
        public async Task Post_DbFails_ReturnsError()
        {
            var errorMessage = "UserName exists.";
            var errors = new List<string>() { errorMessage };
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new CreateUserResponse("", false, errors)));

            // fakes
            var outputPort = new RegisterUserPresenter();
            var useCase = new RegisterUserUseCase(mockUserRepository.Object);

            var controller = new RegisterController(useCase, outputPort);

            // act
            var result = await controller.Post(new RegisterUserRequest());

            // assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, ((JsonContentResult)result).StatusCode);
            Assert.IsTrue(((JsonContentResult)result).Content.Contains(errorMessage));
        }
    }
}