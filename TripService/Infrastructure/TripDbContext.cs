using KayakTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using KayakTracker.Domain.Models;

namespace KayakTracker.Infrastructure
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<River>().HasData(
                new River
                {
                    Id = 1,
                    Name = "Test River",
                    State = KayakTracker.Domain.Enums.StateEnum.OH,
                    Description = "Test River"
                }
            );

            // Seed data
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    DistanceMiles = 10,
                    StartDate = DateTime.UtcNow.ToUniversalTime(),
                    EndDate = DateTime.UtcNow.ToUniversalTime(),
                    AvgSpeed = 6,
                    Id = 1,
                    RiverId = 1,
                    OwnerId = "1",
                    StartCoordinates = "37.362,-91.543",
                    StartName = "boat ramp",
                    TimeMinutes = 600,
                    Notes = "notes",
                }
            );

            // Seed data
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Text = "My test comment about the river",
                    TripId = 1,
                    UserId = "1",
                }
            );
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<River> Rivers { get; set; }
    }
}
