using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult InicioSesion([FromBody] UserLoginRequest userLogin)
    {
        return Ok(new { mensaje = "Hola yo soy un POST", cuerpo = $"Gracias tu usuario es: {userLogin.Username} Tu contraseña es: {userLogin.Password}"});
    }
    [HttpGet]
    public IActionResult InicioSesion1()
    {
        return Ok(new { mensaje = "Hola yo soy un GET" });
    }
}
