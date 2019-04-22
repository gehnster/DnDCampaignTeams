using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDCampaignTeams;
using DnDCampaignTeams.Models;

namespace DnDCampaignTeams.Pages.Character
{
    public class EditModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;

        public EditModel(DnDCampaignTeams.DnDCampaignTeamsContext context)
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
           ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(Character.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
