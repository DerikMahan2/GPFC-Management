using System.ComponentModel.DataAnnotations;

namespace GPFC_Management.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        // Foreign key
        public int TeamId { get; set; }

        // Navigation property
        public Team Team { get; set; }
    }
}