using FootballLeague.Data;
using FootballLeague.Models;
using System.Collections.Generic;
using System.Linq;

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
            var leagueTable = _context.LeagueTables
                .Include(l => l.Team)
                .OrderByDescending(l => l.Points)
                .ThenByDescending(l => l.GoalDifference)
                .ToList();
            return leagueTable;
        }
    }
}
