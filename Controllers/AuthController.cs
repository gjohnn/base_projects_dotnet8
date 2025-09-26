using base_project.Models;
using base_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace base_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthController(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var user = await _authService.Register(request.Email, request.Password);
                return Ok(new { user.Id, user.Email });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _authService.Login(request.Email, request.Password);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        // POST: api/auth/request-reset-password
        [HttpPost("request-reset-password")]
        public async Task<IActionResult> RequestResetPassword([FromBody] ResetPasswordRequest request)
        {
            // Aquí podés generar un token temporal y enviarlo por mail
            var token = Guid.NewGuid().ToString(); // ejemplo simple
            // Guardalo en DB asociado al usuario con expiración
            return Ok(new { message = "Token de reseteo generado", token });
        }

        // POST: api/auth/confirm-reset-password
        [HttpPost("confirm-reset-password")]
        public async Task<IActionResult> ConfirmResetPassword([FromBody] ConfirmResetPasswordRequest request)
        {
            var user = await _userService
                .GetByEmailAsync(request.Email);

            if (user == null)
                return BadRequest(new { error = "Usuario no encontrado" });

            // Validar token aquí contra lo guardado en DB
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            await _userService.UpdateAsync(user);

            return Ok(new { message = "Contraseña actualizada" });
        }
    }

    // DTOs
    public class RegisterRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class ResetPasswordRequest
    {
        public string Email { get; set; } = null!;
    }

    public class ConfirmResetPasswordRequest
    {
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
