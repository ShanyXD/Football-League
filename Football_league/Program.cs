
using FootballLeague;
using FootballLeague.Data;
using FootballLeague.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague_WithORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<FootballLeagueContext>(options =>
                    options.UseMySql("server=localhost; database=football_league; user=root; password=your_password",
                    new MySqlServerVersion(new Version(8, 2, 12))))
                .AddScoped<TeamService>()
                .AddScoped<MatchService>()
                .AddScoped<LeagueService>()
                .BuildServiceProvider();

            using (var context = serviceProvider.GetRequiredService<FootballLeagueContext>())
            {
                context.Database.Migrate();
            }

            var teamService = serviceProvider.GetRequiredService<TeamService>();
            var matchService = serviceProvider.GetRequiredService<MatchService>();
            var leagueService = serviceProvider.GetRequiredService<LeagueService>();

            var display = new Display(teamService, matchService, leagueService);
            display.ShowMainMenu();
        }
    }
}
