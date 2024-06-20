using Football_league.Data;
using Football_league.Models;
using Microsoft.EntityFrameworkCore;

namespace Football_league.Services
{
    public class MatchService
    {
        private readonly FootballLeagueContext _context;

        public MatchService(FootballLeagueContext context)
        {
            _context = context;
        }
        //dddd

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
