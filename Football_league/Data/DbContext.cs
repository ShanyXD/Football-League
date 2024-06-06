using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Football_league.Models;

public class FootballLeagueContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Matches> Matches { get; set; }
    public DbSet<Standing> Standings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=FootballLeague;user=root;password=",
            new MySqlServerVersion(new Version(8, 2, 12)));
    }
}
