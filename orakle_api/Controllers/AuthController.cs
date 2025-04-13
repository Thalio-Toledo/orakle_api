using Microsoft.AspNetCore.Mvc;
using orakle_api.DTOs;
using orakle_api.services;

namespace orakle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController :ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok("User registred with success.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
    }
}
