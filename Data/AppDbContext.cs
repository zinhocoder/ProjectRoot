using Microsoft.EntityFrameworkCore;
using ProjectRoot.Models;

namespace ProjectRoot.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<SuiteType> SuiteTypes { get; set; }
        public DbSet<Motel> Motels { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
