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
    public class DeleteModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;

        public DeleteModel(DnDCampaignTeams.DnDCampaignTeamsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Character Character { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Characters
                .Include(c => c.Player).FirstOrDefaultAsync(m => m.Id == id);

            if (Character == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Characters.FindAsync(id);

            if (Character != null)
            {
                _context.Characters.Remove(Character);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
