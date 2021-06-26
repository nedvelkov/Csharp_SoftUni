namespace GitWebApp.Data
{
    using GitWebApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
   public class GitDbContext: DbContext
    {
        public DbSet<User> GitUsers { get; init; }

        public DbSet<Repository> Repositories { get; init; }

        public DbSet<Commit> Commits { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CarShop;Integrated Security=True;");
            }
        }
    }
}
