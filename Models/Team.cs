using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPFCManagementSystem.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string TeamName { get; set; }

        public string CoachName { get; set; }

        public string Division { get; set; }

        // Navigation property
        public ICollection<Player> Players { get; set; }
    }
}