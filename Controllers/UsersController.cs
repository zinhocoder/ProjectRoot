namespace ProjectRoot.Controllers
{
    using Microsoft.AspNetCore.Identity.Data;
    using Microsoft.AspNetCore.Mvc;
    using ProjectRoot.Data;
    using ProjectRoot.Models;
    using System.Linq;

    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Models.RegisterRequest request)
        {
            if (_context.Users.Any(u => u.Username == request.Username))
            {
                return BadRequest("Usuário já existe.");
            }

            var user = new User
            {
                Username = request.Username,
                PasswordHash = request.Password 
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Usuário registrado com sucesso.");
        }
    }
}