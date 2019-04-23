using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCampaignTeams.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name="Logo")]
        public string LogoLocation { get; set; }
        public List<Character> Characters { get; set; }
    }
}
