using System.Text.Json;
using Login.Models;
using Login.Services;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly string archivoUsuarios = Directory.GetCurrentDirectory() + "/Data/usuarios.json";
        
        private readonly IFileService _fileService;

        public UserController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // Método para leer los usuarios del archivo JSON
        private List<Usuario> LeerUsuarios()
        {
            if (!_fileService.Exists(archivoUsuarios))
            {
                return new List<Usuario>(); // Si el archivo no existe, devuelve una lista vacía.
            }

            string json = _fileService.ReadAllText(archivoUsuarios);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }

        // Método para guardar los usuarios en el archivo JSON
        private void GuardarUsuarios(List<Usuario> usuarios)
        {
            string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            _fileService.WriteAllText(archivoUsuarios, json);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest register)
        {
            // Leer la lista de usuarios
            List<Usuario> usuarios = LeerUsuarios();

            // Verificar si el nombre de usuario ya está registrado
            if (usuarios.Any(u => u.NombreUsuario == register.UsernameRegister))
            {
                return Conflict(new UserLoginResponse() { Message = "El nombre de usuario ya está en uso" });
            }

            // Agregar el nuevo usuario a la lista
            Usuario nuevoUsuario = new Usuario
            {
                NombreUsuario = register.UsernameRegister,
                Contraseña = register.PasswordRegister
            };
            usuarios.Add(nuevoUsuario);

            // Guardar la lista de usuarios actualizada en el archivo JSON
            GuardarUsuarios(usuarios);

            return Ok(new UserLoginResponse { Message = "Te has registrado exitosamente" });
        }

    
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest login)
        {
            // Leer la lista de usuarios
            List<Usuario> usuarios = LeerUsuarios();

            // Verificar las credenciales
            Usuario? usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == login.Username && u.Contraseña == login.Password);
            if (usuario != null)
            {
                return Ok(new UserLoginResponse { Message = "Inicio de sesión exitoso" });
            }

            return Unauthorized(new UserLoginResponse { Message = "Credenciales incorrectas" });
        }
    }
}