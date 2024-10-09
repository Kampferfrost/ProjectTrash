using Microsoft.EntityFrameworkCore;

namespace SpeedRunDBLearn
{
    internal class AnimeGirlsContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public AnimeGirlsContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AnimeGirls.db");
        }

    }



}
