using FootballLeague.Services;
using FootballLeague.Models;
using System;


namespace FootballLeague
{
    public class Display
    {
        private readonly TeamService _teamService;
        private readonly MatchService _matchService;
        private readonly LeagueService _leagueService;

        public Display(TeamService teamService, MatchService matchService, LeagueService leagueService)
        {
            _teamService = teamService;
            _matchService = matchService;
            _leagueService = leagueService;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Football League Manager");
                Console.WriteLine("1) Show Teams");
                Console.WriteLine("2) Add Team");
                Console.WriteLine("3) Show Matches");
                Console.WriteLine("4) Add Match");
                Console.WriteLine("5) Show League Table");
                Console.WriteLine("6) Exit");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ShowTeams(); break;
                    case "2": AddTeam(); break;
                    case "3": ShowMatches(); break;
                    case "4": AddMatch(); break;
                    case "5": ShowLeagueTable(); break;
                    case "6": return;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }

        private void ShowTeams()
        {
            Console.Clear();
            var teams = _teamService.GetTeams();
            foreach (var team in teams)
            {
                Console.WriteLine($"{team.TeamID}: {team.TeamName}");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void AddTeam()
        {
            Console.Clear();
            Console.Write("Enter team name: ");
            var teamName = Console.ReadLine();

            var team = new Team { TeamName = teamName };
            _teamService.AddTeam(team);
            Console.WriteLine("Team added successfully!");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void ShowMatches()
        {
            Console.Clear();
            var matches = _matchService.GetMatches();
            foreach (var match in matches)
            {
                Console.WriteLine($"{match.MatchID}: {match.HomeTeam.TeamName} {match.HomeScore} - {match.AwayScore} {match.AwayTeam.TeamName} on {match.MatchDate}");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void AddMatch()
        {
            Console.Clear();
            var teams = _teamService.GetTeams();

            Console.WriteLine("Select home team:");
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {teams[i].TeamName}");
            }
            var homeTeamIndex = int.Parse(Console.ReadLine()) - 1;
            var homeTeam = teams[homeTeamIndex];

            Console.WriteLine("Select away team:");
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {teams[i].TeamName}");
            }
            var awayTeamIndex = int.Parse(Console.ReadLine()) - 1;
            var awayTeam = teams[awayTeamIndex];

            Console.Write("Enter home team score: ");
            var homeScore = int.Parse(Console.ReadLine());

            Console.Write("Enter away team score: ");
            var awayScore = int.Parse(Console.ReadLine());

            var match = new Match
            {
                HomeTeamID = homeTeam.TeamID,
                AwayTeamID = awayTeam.TeamID,
                HomeScore = homeScore,
                AwayScore = awayScore,
                MatchDate = DateTime.Now
            };

            _matchService.AddMatch(match);
            Console.WriteLine("Match added successfully!");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void ShowLeagueTable()
        {
            Console.Clear();
            var leagueTable = _leagueService.GetLeagueTable();

            Console.WriteLine("League Table:");
            foreach (var entry in leagueTable)
            {
                Console.WriteLine($"{entry.Team.TeamName}: Played {entry.Played}, Won {entry.Won}, Drawn {entry.Drawn}, Lost {entry.Lost}, GF {entry.GoalsFor}, GA {entry.GoalsAgainst}, GD {entry.GoalDifference}, Points {entry.Points}");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}
