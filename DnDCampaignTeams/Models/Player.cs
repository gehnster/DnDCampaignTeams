using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDCampaignTeams.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(37, MinimumLength = 2, ErrorMessage = "Discord Handle should be between 2 and 37 characters long")]
        [Display(Name = "Discord Handle")]
        public string DiscordHandle { get; set; }
        public List<Character> Characters { get; set; }
    }
}
