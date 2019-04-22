using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DnDCampaignTeams;
using DnDCampaignTeams.Models;

namespace DnDCampaignTeams.Pages.Player
{
    public class DetailsModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;

        public DetailsModel(DnDCampaignTeams.DnDCampaignTeamsContext context)
        {
            _context = context;
        }

        public Models.Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FirstOrDefaultAsync(m => m.Id == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
