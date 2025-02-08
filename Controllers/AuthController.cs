namespace ProjectRoot.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectRoot.Models;
    using ProjectRoot.Services;
    using ProjectRoot.Data;
    using System.Linq;
    using Microsoft.AspNetCore.Identity.Data;

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == request.Username);

            if (user == null || user.PasswordHash != request.Password) // Comparação direta ⚠️
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            var token = _tokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}