namespace ProjectRoot.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProjectRoot.Data;
    using ProjectRoot.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations([FromQuery] DateTime? date)
        {
            var query = _context.Reservations.AsQueryable();
            if (date.HasValue)
            {
                query = query.Where(r => r.CheckIn.Date == date.Value.Date);
            }
            return await query.ToListAsync();
        }
    }
}