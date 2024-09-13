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
    public class UserControllerLoginTests
    {
        private Mock<IFileService> _mockFileService = new(MockBehavior.Strict);
        [Fact]
        public void Should_Login_With_Valid_Username()
        {
            //Arrange
            const string username = "juan123";
            const string password = "12345";
            var request = new UserLoginRequest{Username = username, Password = password};

            //Mock
            _mockFileService.Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(true);
            _mockFileService.Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns(JsonSerializer.Serialize(new List<Usuario>(){new(){NombreUsuario = username,Contraseña = password}}));
            
            //Act
            var controller = new UserController(_mockFileService.Object);
            var result = controller.Login(request) as ObjectResult;  

            //Assert
            result?.StatusCode.Should().Be(StatusCodes.Status200OK, result.Value?.ToString());
            (result!.Value as UserLoginResponse)!.Message.Should().Be("Inicio de sesión exitoso");
        }
        
        [Fact]
        public void When_Incorrect_Username_Then_Error_Is_Returned()
        {
            //Arrange
            var request = new UserLoginRequest{Username = "incorrect", Password = "incorrect"};

            //Mock
            _mockFileService.Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(true);
            _mockFileService.Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns(JsonSerializer.Serialize(new List<Usuario>()));
            
            //Act
            var controller = new UserController(_mockFileService.Object);
           var result = controller.Login(request) as ObjectResult;

            //Assert
            result?.StatusCode.Should().Be(StatusCodes.Status401Unauthorized, result.Value?.ToString());
            (result!.Value as UserLoginResponse)!.Message.Should().Be("Credenciales incorrectas");
        }
    }
}