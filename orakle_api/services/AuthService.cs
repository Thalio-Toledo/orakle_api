using Microsoft.AspNetCore.Identity;
using orakle_api.DTOs;
using orakle_api.Entities;
using orakle_api.Interfaces;

namespace orakle_api.services
{
    public class AuthService
    {
        private readonly UserManager<Owner> _userManager;
        private readonly SignInManager<Owner> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<Owner> userManager, SignInManager<Owner> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if(user == null)
                throw new UnauthorizedAccessException("Invalid User!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid Password");

            var token = _tokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                OwnerId = user.Id,
                Email = user.Email,
                Token = token
            };
        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
            var user = new Owner { ProfileName = dto.Name, UserName = dto.Email, Email = dto.Email };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Error to register: {errors}");
            }
        }
    }
}
