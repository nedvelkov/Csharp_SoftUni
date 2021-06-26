namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Trip> Trips { get; init; }
        public DbSet<UserTrip> UserTrips { get; init; }
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>().HasKey(k => new { k.UserId, k.TripId });

            modelBuilder.Entity<UserTrip>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserTrips)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserTrip>()
                         .HasOne(x => x.Trip)
                         .WithMany(x => x.UserTrips)
                         .HasForeignKey(x => x.TripId)
                         .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
