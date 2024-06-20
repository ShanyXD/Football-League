using Microsoft.EntityFrameworkCore;
using Football_league.Models;
using Football_league.Data;

namespace Football_League.Services
{
    public class LeagueService
    {
        private readonly FootballLeagueContext _context;

        public LeagueService(FootballLeagueContext context)
        {
            _context = context;
        }

        public List<TeamInfo> GetLeagueTable()
        {
            
            var teams = _context.Teams.Include(t => t.HomeMatches).Include(t => t.AwayMatches).ToList();
            var leagueTable = new List<TeamInfo>();

            foreach (var team in teams)
            {
                var leagueEntry = new TeamInfo
                {
                    TeamID = team.TeamID,
                    Team = team.TeamName,
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
                              .ThenByDescending(lt => lt.GoalsFor - lt.GoalsAgainst)
                              .ThenByDescending(lt => lt.GoalsFor)
                              .ToList();
        }

        //public List<TeamInfo> GetLeagueTable()
        //{
           // var leagueTable = _context.LeagueTables
              //  .Include(l => l.Team)
            //    .OrderByDescending(l => l.Points)
               // .ThenByDescending(l => l.GoalDifference)
              //  .ToList();
            //return leagueTable;
       // }
    }
}
