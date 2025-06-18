using AppAvanza.Application.Dtos.Auth;
using AppAvanza.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppAvanza.API.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistroFacilitadorDto registroDto)
        {
            try
            {
                var usuario = await _authService.RegistrarFacilitadorAsync(registroDto);
                return Ok(new { Id = usuario.Id, Nombre = usuario.Nombre, Email = usuario.Email, Rol = usuario.Rol.ToString() });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex) // Catch-all for other potential errors
            {
                // Log the exception (ex) with a proper logging mechanism
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var tokenDto = await _authService.LoginAsync(loginDto);

                if (tokenDto == null)
                {
                    return Unauthorized(new { message = "Credenciales inválidas." });
                }
                return Ok(tokenDto);
            }
            catch (InvalidOperationException ex) // Catch configuration errors from AuthService
            {
                // Log the exception (ex)
                return StatusCode(500, new { message = $"Error de configuración del servidor: {ex.Message}" });
            }
            catch (Exception ex) // Catch-all for other potential errors
            {
                // Log the exception (ex)
                return StatusCode(500, new { message = "An unexpected error occurred during login." });
            }
        }
    }
}
