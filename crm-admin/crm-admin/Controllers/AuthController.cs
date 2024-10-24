using System.Threading.Tasks;
using crm_admin.DTOs;
using crm_admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace crm_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _authService.Authenticate(loginDto.Email, loginDto.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Email o contraseña incorrectos" });
            }

            return Ok(new { message = "Login exitoso", usuario = user.NombreUsuario, rol = user.Rol });
        }
    }
}
