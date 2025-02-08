namespace ProjectRoot.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectRoot.Data;
    using ProjectRoot.Models;
    using System.Linq;

    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult RegisterClient([FromBody] Client client)
        {
            if (_context.Clients.Any(c => c.Email == client.Email))
            {
                return BadRequest("Client already exists");
            }

            client.Id = 0; // Garante que o banco gere o ID automaticamente

            _context.Clients.Add(client);
            _context.SaveChanges();
            return Ok(client);
        }
    }
}
