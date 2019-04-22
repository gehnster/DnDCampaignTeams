using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DnDCampaignTeams;
using DnDCampaignTeams.Models;

namespace DnDCampaignTeams.Pages.Character
{
    public class CreateModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;

        public CreateModel(DnDCampaignTeams.DnDCampaignTeamsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.Character Character { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Characters.Add(Character);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}