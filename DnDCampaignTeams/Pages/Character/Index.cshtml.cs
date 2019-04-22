using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DnDCampaignTeams;
using DnDCampaignTeams.Models;

namespace DnDCampaignTeams.Pages.Character
{
    public class IndexModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;

        public IndexModel(DnDCampaignTeams.DnDCampaignTeamsContext context)
        {
            _context = context;
        }

        public IList<Models.Character> Character { get;set; }

        public async Task OnGetAsync()
        {
            Character = await _context.Characters
                .Include(c => c.Player).ToListAsync();
        }
    }
}
