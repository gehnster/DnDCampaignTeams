using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DnDCampaignTeams;
using DnDCampaignTeams.Models;

namespace DnDCampaignTeams.Pages.Campaign
{
    public class DetailsModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;

        public DetailsModel(DnDCampaignTeams.DnDCampaignTeamsContext context)
        {
            _context = context;
        }

        public Models.Campaign Campaign { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campaign = await _context.Campaigns.FirstOrDefaultAsync(m => m.Id == id);

            if (Campaign == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
