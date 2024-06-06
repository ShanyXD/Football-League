using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FootballLeague.Data;

namespace FootballLeague.Services
{
    public class LeagueService
    {
        private readonly FootballLeagueContext _context;

        public LeagueService(FootballLeagueContext context)
        {
            _context = context;
        }

        public List<LeagueTable> GetLeagueTable()
        {
            // Here you need to calculate the league table based on matches
            var teams = _context.Teams.Include(t => t.HomeMatches).Include(t => t.AwayMatches).ToList();
            var leagueTable = new List<LeagueTable>();

            foreach (var team in teams)
            {
                var leagueEntry = new LeagueTable
                {
                    TeamID = team.TeamID,
                    Team = team,
                    Played = 0,
                    Won = 0,
                    Drawn = 0,
                    Lost = 0,
                    GoalsFor = 0,
                    GoalsAgainst = 0,
                    Points = 0
                };

                foreach (var match in team.HomeMatches)
                {
                    leagueEntry.Played++;
                    leagueEntry.GoalsFor += match.HomeScore;
                    leagueEntry.GoalsAgainst += match.AwayScore;

                    if (match.HomeScore > match.AwayScore) leagueEntry.Won++;
                    else if (match.HomeScore == match.AwayScore) leagueEntry.Drawn++;
                    else leagueEntry.Lost++;
                }

                foreach (var match in team.AwayMatches)
                {
                    leagueEntry.Played++;
                    leagueEntry.GoalsFor += match.AwayScore;
                    leagueEntry.GoalsAgainst += match.HomeScore;

                    if (match.AwayScore > match.HomeScore) leagueEntry.Won++;
                    else if (match.AwayScore == match.HomeScore) leagueEntry.Drawn++;
                    else leagueEntry.Lost++;
                }

                leagueEntry.Points = leagueEntry.Won * 3 + leagueEntry.Drawn;
                leagueTable.Add(leagueEntry);
            }

            return leagueTable.OrderByDescending(lt => lt.Points)
                              .ThenByDescending(lt => lt.GoalDifference)
                              .ThenByDescending(lt => lt.GoalsFor)
                              .ToList();
        }
    }
}
