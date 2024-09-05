
namespace UserRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromForm] string username, [FromForm] string password)
        {
            // Aquí podrías validar y almacenar los datos en la base de datos.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Usuario o contraseña no válidos.");
            }

            // Simulación de almacenamiento de datos
            // Aquí deberías agregar lógica para guardar en base de datos.
            return Ok("Registro exitoso");
        }
    }
}