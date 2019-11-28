using CodingChallenge.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Api.Data
{
    public class ChallengeDbContext : DbContext
    {
        public ChallengeDbContext(DbContextOptions options)
            : base(options) 
        {
            
        }

        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medication>()
                .HasKey(p => p.Id);
        }
    }
}
