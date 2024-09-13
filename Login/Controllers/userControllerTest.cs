using Xunit; // Framework de pruebas unitarias
using Moq;   // Biblioteca para mocks
using Microsoft.AspNetCore.Mvc;

public class UserControllerTests
{
    [Fact]
public void Login_CorrectCredentials_ReturnsOk()
{   
    
    // Arrange
    var loginRequest = new UserLoginRequest
    {
        Username = "juan123",
        Password = "12345"
    };

    var controller = new UserController();

    // Act
    var result = controller.Login(loginRequest);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.Equal(200, okResult.StatusCode);
    
    // Aquí usamos ResponseMessage en lugar de dynamic
    var response = Assert.IsType<ResponseMessage>(okResult.Value);
    Assert.Equal("Inicio de sesión exitoso", response.Message);
}

[Fact]
public void Login_IncorrectCredentials_ReturnsUnauthorized()
{
    // Arrange
    var loginRequest = new UserLoginRequest
    {
        Username = "wronguser",
        Password = "wrongpassword"
    };

    var controller = new UserController();

    // Act
    var result = controller.Login(loginRequest);

    // Assert
    var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
    Assert.Equal(401, unauthorizedResult.StatusCode);

    // Aquí usamos ResponseMessage en lugar de dynamic
    var response = Assert.IsType<ResponseMessage>(unauthorizedResult.Value);
    Assert.Equal("Credenciales incorrectas", response.Message);
}

}
