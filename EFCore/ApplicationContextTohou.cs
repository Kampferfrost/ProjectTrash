using Microsoft.EntityFrameworkCore;


namespace EFCore
{
    internal class ApplicationContextTohou : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Tiger> Tigers { get; set; } = null!;
        public ApplicationContextTohou()  => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=cirnoapp.db");
        }

    }

}
