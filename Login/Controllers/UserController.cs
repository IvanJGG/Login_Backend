using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    [HttpPost("iniciosesion")]
    public IActionResult InicioSesion([FromBody] UserLoginRequest userLogin)
    {
        return Ok(new { mensaje = "Hola yo soy un POST", cuerpo = $"Gracias tu usuario es: {userLogin.Username} Tu contraseña es: {userLogin.Password}"});
    }
    [HttpGet]
    public IActionResult InicioSesion1()
    {
        return Ok(new { mensaje = "Hola yo soy un GET" });
    }
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
