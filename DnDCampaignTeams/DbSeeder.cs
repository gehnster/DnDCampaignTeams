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

            var campaigns = new Campaign[]
            {
                new Campaign { Name = "The Mighty Nein", Description = "It takes place in 835 P.D., approximately twenty years after the adventures of Vox Machina.", LogoLocation="MN_Logo_Simplified.png"},
                new Campaign { Name = "Vox Machina", Description = "Vox Machina was a legendary band of adventurers based in Tal'Dorei", LogoLocation="VM_Symbol_b.png"},
                new Campaign { Name = "Demo Campaign", Description = "The most deadly of campaigns. Join at your own peril!", LogoLocation="161573-chuunibyou-demo-koi-ga-shitai-chibi-rikka_376f.gif"}
            };
            foreach (var c in campaigns)
            {
                context.Campaigns.Add(c);
            }

            context.SaveChanges();

            var players = new Player[]
            {
                new Player { FirstName = "Matthew", LastName = "Park", DiscordHandle = "Gehn#0000" },
                new Player { FirstName = "Travis", LastName = "Willingham", DiscordHandle = "Travis#0000" },
                new Player { FirstName = "Laura", LastName = "Bailey", DiscordHandle = "Laura#0000" },
                new Player { FirstName = "Sam", LastName = "Riegel", DiscordHandle = "Sam#0000" },
                new Player { FirstName = "Marisha", LastName = "Ray", DiscordHandle = "Marisha#0000" },
                new Player { FirstName = "Liam", LastName = "O'Brien", DiscordHandle = "Liam#0000" },
                new Player { FirstName = "Ashley", LastName = "Johnson" },
                new Player { FirstName = "Taliesin" },
                new Player { FirstName="No", LastName="Characters" }
            };
            foreach(var p in players)
            {
                context.Players.Add(p);
            }

            context.SaveChanges();

            var characters = new Character[]
            {
                new Character { Name="Gehn", Alive=true, Class="Sorcerer", Level=20, PlayerId = 1, AvatarLocation="ymhchYJ.gif", CampaignId=3 },
                new Character { Name="Jester", Alive=true, Class="Cleric", Level=9, PlayerId = 3, AvatarLocation="Jester.jpg", CampaignId=1 },
                new Character { Name="Yasha", Alive=true, Class="Barbarian", Level=9, PlayerId = 6, AvatarLocation="Yasha.jpg", CampaignId=1 },
                new Character { Name="Caduceus", Alive=true, Class="Cleric", Level=9, PlayerId = 7, AvatarLocation="Caduceus_portrait.jpg", CampaignId=1 },
                new Character { Name="Caleb", Alive=true, Class="Wizard", Level=9, PlayerId = 5, AvatarLocation="Caleb_Widogast.jpg", CampaignId=1 },
                new Character { Name="Nott", Alive=true, Class="Rogue", Level=9, PlayerId = 3, AvatarLocation="Nott.jpg", CampaignId=1 },
                new Character { Name="Beauregard", Alive=true, Class="Monk", Level=9, PlayerId = 4, AvatarLocation="Beauregard.jpg", CampaignId=1 },
                new Character { Name="Fjord", Alive=true, Class="Warlock", Level=9, PlayerId = 2, AvatarLocation="Fjord.jpg", CampaignId=1 },
                new Character { Name="Molly", Alive=false, Class="Blood Hunter", Level=5, PlayerId = 7, AvatarLocation="Mollymauk.jpg", CampaignId=1 },
                new Character { Name="Grog", Alive=true, Class="Barbarian", Level=20, PlayerId = 2, AvatarLocation="Grog2.png", CampaignId=2 },
                new Character { Name="Percy", Alive=true, Class="Fighter", Level=20, PlayerId = 7, AvatarLocation="Percy2.png", CampaignId=2 },
                new Character { Name="Pike", Alive=true, Class="Cleric", Level=20, PlayerId = 6, AvatarLocation="Pike2.png", CampaignId=2 },
                new Character { Name="Vex'ahlia", Alive=true, Class="Ranger", Level=20, PlayerId = 3, AvatarLocation="Vexahlia2.jpg", CampaignId=2 },
                new Character { Name="Scanlan", Alive=true, Class="Bard", Level=20, PlayerId = 3, AvatarLocation="Scanlan2.png", CampaignId=2 },
                new Character { Name="Vaxildan", Alive=true, Class="Rogue", Level=20, PlayerId = 5, AvatarLocation="Vaxildan2.png", CampaignId=2 },
                new Character { Name="Keyleth", Alive=true, Class="Druid", Level=20, PlayerId = 4, AvatarLocation="Keyleth2.png", CampaignId=2 },
                new Character { Name="NoCampaign Character", Alive=true, Class="Mage", Level=1, PlayerId=1 }
            };
            foreach (var c in characters)
            {
                context.Characters.Add(c);
            }

            context.SaveChanges();
        }
    }
}
