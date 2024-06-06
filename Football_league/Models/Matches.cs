using FootballLeague.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeague.Models
{
    public class Match
    {
        [Key]
        public int MatchID { get; set; }

        public int HomeTeamID { get; set; }
        [ForeignKey("HomeTeamID")]
        public Team HomeTeam { get; set; }

        public int AwayTeamID { get; set; }
        [ForeignKey("AwayTeamID")]
        public Team AwayTeam { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
