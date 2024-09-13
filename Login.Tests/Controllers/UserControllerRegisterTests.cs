using System.Text.Json;
using FluentAssertions;
using Login.Controllers;
using Login.Models;
using Login.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Login.Tests.Controllers
{
    public class UserControllerRegisterTests
    {
        private Mock<IFileService> _mockFileService = new(MockBehavior.Strict);

        [Fact]
        public void Should_register_a_user_with_given_email_and_password()
        {
            //Arrange
            UserRegisterRequest request = new() { UsernameRegister = "test", PasswordRegister = "test" };

            //Mock
            _mockFileService.Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(false);
            _mockFileService.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()));

            //Act
            var controller = new UserController(_mockFileService.Object);
            var result = controller.Register(request) as ObjectResult;
            
            //Assert
            result?.StatusCode.Should().Be(StatusCodes.Status200OK, result.Value?.ToString());
        }

        [Fact]
        public void Should_validate_existing_user_with_given_email_and_password()
        {
            //Arrange
            var usernameRegister = "test";
            UserRegisterRequest request = new() { UsernameRegister = usernameRegister, PasswordRegister = usernameRegister };

            //Mock
            _mockFileService.Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(true);
            _mockFileService.Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns(JsonSerializer.Serialize(new List<Usuario>(){new(){NombreUsuario = usernameRegister,Contraseña = usernameRegister}}));
            _mockFileService.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()));

            //Act
            var controller = new UserController(_mockFileService.Object);
            var result = controller.Register(request) as ObjectResult;
            
            //Assert
            result?.StatusCode.Should().Be(StatusCodes.Status409Conflict, result.Value?.ToString());
        }
    }
}