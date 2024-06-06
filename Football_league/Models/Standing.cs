using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeague.Models
{
    public class Standing
    {
        [Key]
        public int TeamID { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Points { get; set; }

        [ForeignKey("TeamID")]
        public Team Team { get; set; }
    }
}
