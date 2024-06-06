using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class TeamsController : Controller
{
    private readonly FootballLeagueContext _context;

    public TeamsController(FootballLeagueContext context)
    {
        _context = context;
    }

    // Action methods for creating, reading, updating, and deleting teams
}

public class MatchesController : Controller
{
    private readonly FootballLeagueContext _context;

    public MatchesController(FootballLeagueContext context)
    {
        _context = context;
    }

    // Action methods for creating, reading, updating, and deleting matches
}

public class StandingsController : Controller
{
    private readonly FootballLeagueContext _context;

    public StandingsController(FootballLeagueContext context)
    {
        _context = context;
    }

    // Action methods for viewing standings
}

