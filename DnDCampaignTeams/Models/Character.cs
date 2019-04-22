using System.ComponentModel.DataAnnotations;

namespace DnDCampaignTeams.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Making class a string for the sake of brevity.
        public string Class { get; set; }
        public bool Alive { get; set; } = true;
        [Range(1, int.MaxValue)]
        public int Level { get; set; }
        public byte[] Avatar { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
