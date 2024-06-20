using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Football_league.Models
{
    public class TeamInfo
    {
        public int TeamID { get; set; }
        public string Team { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }

        
    }
}
