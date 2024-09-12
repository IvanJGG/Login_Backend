using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginRequest request)
    {
        // Aquí puedes verificar el username y password
        if (request.Username == "juan123" && request.Password == "12345")
        {
            return Ok(new { Message = "Inicio de sesión exitoso" });
        }
        return Unauthorized(new { Message = "Credenciales incorrectas" });
    }
}
