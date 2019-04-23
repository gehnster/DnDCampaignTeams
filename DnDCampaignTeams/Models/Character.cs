using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDCampaignTeams.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // Making class a string for the sake of brevity.
        public string Class { get; set; }
        public bool Alive { get; set; } = true;
        [Range(1, int.MaxValue)]
        public int Level { get; set; }
        [Display(Name="Avatar")]
        public string AvatarLocation { get; set; }
        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public Player Player { get; set; }

    }
}
