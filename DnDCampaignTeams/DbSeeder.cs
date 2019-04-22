using DnDCampaignTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCampaignTeams
{
    public static class DbSeeder
    {
        public static void Initialize(DnDCampaignTeamsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player { Id = 1, FirstName = "Matthew", LastName = "Park", DiscordHandle = "Gehn#0000" }
            };
            foreach(var p in players)
            {
                context.Players.Add(p);
            }

            context.SaveChanges();
        }
    }
}
