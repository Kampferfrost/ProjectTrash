using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class ApplicationContextWet : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContextWet() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Koikatsu.db");
        }

    }


}


