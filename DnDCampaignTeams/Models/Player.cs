using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDCampaignTeams.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(37, MinimumLength = 2, ErrorMessage = "Discord Handle should be between 2 and 37 characters long")]
        public string DiscordHandle { get; set; }
        //[InverseProperty("Player")]
        public List<Character> Characters { get; set; }
    }
}
