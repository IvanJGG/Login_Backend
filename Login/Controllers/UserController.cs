using Login.Models;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
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
                return Ok(new UserLoginResponse { Message = "Inicio de sesión exitoso" });
            }
            return Unauthorized(new UserLoginResponse { Message = "Credenciales incorrectas" });
        }
    }
}