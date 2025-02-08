namespace ProjectRoot.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProjectRoot.Data;
    using ProjectRoot.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/motels")]
    [ApiController]
    public class MotelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotelsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motel>>> GetMotels()
        {
            return await _context.Motels.Include(m => m.Suites).ToListAsync();
        }
    }
}