using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PersonalPage.Core.UnitTests
{
    [TestFixture]
    public class RegisterUserUseCaseUnitTests
    {
        [Test]
        public async Task Can_Register_User()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
              .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
              .Returns(Task.FromResult(new CreateUserResponse("", true)));

            var useCase = new RegisterUserUseCase(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RegisterUserResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RegisterUserResponse>()));

            var response = await useCase.Handle(new RegisterUserRequestDto("userName", "user@mail.ru",  "password"), mockOutputPort.Object);

            Assert.True(response);
        }
    }
}