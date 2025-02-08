using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProjectRoot.Data;
using ProjectRoot.Models;

namespace ProjectRoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RevenueController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint para obter o faturamento mensal
        [HttpGet("monthly-revenue")]
        public async Task<IActionResult> GetMonthlyRevenue(int year, int month)
        {
            // Valida se o mês e o ano são válidos
            if (month < 1 || month > 12 || year < 2000 || year > DateTime.Now.Year)
            {
                return BadRequest("Ano ou mês inválido.");
            }

            // Filtra as reservas para o mês e ano fornecidos
            var revenue = await _context.Reservations
                .Where(r => r.CheckIn.Year == year && r.CheckIn.Month == month)
                .SumAsync(r => r.TotalPrice);

            return Ok(new
            {
                Month = month,
                Year = year,
                TotalRevenue = revenue
            });
        }
    }
}
