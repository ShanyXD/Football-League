using Microsoft.EntityFrameworkCore;
using FootballLeague.Models;

namespace FootballLeague.Data
{
    public class FootballLeagueContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Standing> Standings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=FootballLeague;user=root;password=yourpassword",
                new MySqlServerVersion(new Version(8, 2, 12)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasKey(m => m.MatchID);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamID);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamID);

            modelBuilder.Entity<Standing>()
                .HasKey(s => s.TeamID);
        }
    }
}
