
using Microsoft.EntityFrameworkCore;
using ScorerApp.Entity.Entities;

namespace ScorerApp.DAL.Context
{
    public class ScorerAppDbContext : DbContext
    {
        public ScorerAppDbContext(DbContextOptions<ScorerAppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(c => c.HomeTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
              .HasOne(c => c.AwayTeam)
              .WithMany()
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
