using Microsoft.EntityFrameworkCore;

namespace webapplicationtest.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1434;Initial Catalog=FirstWebApp;Trusted_Connection=Yes;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
