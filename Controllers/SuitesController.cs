    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProjectRoot.Data;
    using ProjectRoot.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace ProjectRoot.Controllers {

    [Route("api/suites")]
    [ApiController]
    public class SuitesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuitesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuiteType>>> GetSuites()
        {
            return await _context.SuiteTypes.ToListAsync();
        }
    }
}