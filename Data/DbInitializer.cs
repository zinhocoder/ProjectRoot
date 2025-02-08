namespace ProjectRoot.Data
{
    using ProjectRoot.Models;
    using System.Linq;

    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Users.Any()) return;

            var users = new User[]
            {
                new User { Username = "admin", PasswordHash = "12345" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
