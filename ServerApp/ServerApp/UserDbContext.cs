using Microsoft.EntityFrameworkCore;

namespace ServerApp
{
    public class UserDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TBTIKPG; Database=UsersDb; TrustServerCertificate = true; User Id=sa;Password=admin;");
        }
        public DbSet<User> Users { get; set; }
    }
}
