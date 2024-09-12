using FluentAssertions;
using Login.Controllers;
using Login.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public void Should_Login_With_Valid_Username()
        {
            //Arrange
            var request = new UserLoginRequest{Username = "juan123", Password = "12345"};

            //Mock
            //Act
            var controller = new UserController();
           var result = controller.Login(request) as ObjectResult;

            //Assert
            result?.StatusCode.Should().Be(StatusCodes.Status200OK, result.Value?.ToString());
            (result.Value as UserLoginResponse).Message.Should().Be("Inicio de sesión exitoso");
        }
        
        [Fact]
        public void When_Incorrect_Username_Then_Error_Is_Returned()
        {
            //Arrange
            var request = new UserLoginRequest{Username = "incorrect", Password = "incorrect"};

            //Mock
            //Act
            var controller = new UserController();
           var result = controller.Login(request) as ObjectResult;

            //Assert
            result?.StatusCode.Should().Be(StatusCodes.Status401Unauthorized, result.Value?.ToString());
            (result.Value as UserLoginResponse).Message.Should().Be("Credenciales incorrectas");
        }
    }
}