using FootballLeague.Data;
using FootballLeague.Models;

using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Services
{
    public class TeamService
    {
        private readonly FootballLeagueContext _context;

        public TeamService(FootballLeagueContext context)
        {
            _context = context;
        }

        public void AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public List<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }
    }
}
