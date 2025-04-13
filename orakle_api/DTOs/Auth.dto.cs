namespace orakle_api.DTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public Guid OwnerId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

}
