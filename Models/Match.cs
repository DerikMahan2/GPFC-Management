using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesGPFC.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime MatchTime { get; set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }

}