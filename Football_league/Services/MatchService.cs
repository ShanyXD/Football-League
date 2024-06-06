using FootballLeague.Data;
using FootballLeague.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Services
{
    public class MatchService
    {
        private readonly FootballLeagueContext _context;

        public MatchService(FootballLeagueContext context)
        {
            _context = context;
        }

        public void AddMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public List<Match> GetMatches()
        {
            return _context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).ToList();
        }
    }
}
