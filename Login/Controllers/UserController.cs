using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult InicioSesion([FromBody] UserRegisterRequest register)
    {
        if (register.Username_register == "juan123" && register.Password_register == "12345")
        {
            return Ok(new { Message = "Te has registrado exitosamente" });
        }
        return Unauthorized(new { Message = "Credenciales incorrectas" });
    }

    [HttpPost("login")]
   public IActionResult Login([FromBody] UserLoginRequest login)
{
    if (login.Username == "juan123" && login.Password == "12345")
    {
        return Ok(new ResponseMessage { Message = "Inicio de sesión exitoso" });
    }
    return Unauthorized(new ResponseMessage { Message = "Credenciales incorrectas" });
}

}
