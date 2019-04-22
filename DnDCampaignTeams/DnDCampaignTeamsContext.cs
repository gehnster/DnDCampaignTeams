using DnDCampaignTeams.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCampaignTeams
{
    public class DnDCampaignTeamsContext : DbContext
    {
        public DnDCampaignTeamsContext() { }
        public DnDCampaignTeamsContext(DbContextOptions<DnDCampaignTeamsContext> options) : base(options) { }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
