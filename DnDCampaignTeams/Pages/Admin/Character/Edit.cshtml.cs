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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Logging;

namespace DnDCampaignTeams.Pages.Admin.Character
{
    public class EditModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;
        private readonly ILogger<EditModel> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EditModel(DnDCampaignTeams.DnDCampaignTeamsContext context, ILogger<EditModel> logger, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public Models.Character Character { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

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
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "FirstName");
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var player = _context.Players.Where(x => x.Id == Character.PlayerId).SingleOrDefault();
            if (player == null)
            {
                _logger.LogError("Player select list allowed user to select a player that doesn't exist.");
                throw new InvalidDataException();
            }

            Character.Player = player;

            if (Character.CampaignId != null)
            {
                var campaign = _context.Campaigns.Where(x => x.Id == Character.CampaignId).SingleOrDefault();
                if (campaign == null)
                {
                    _logger.LogError("Campaign select list allowed user to select a campaign that doesn't exist.");
                    throw new InvalidDataException();
                }

                Character.Campaign = campaign;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                if (!Image.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Image", "File needs to be an image.");
                    return Page();
                }

                var fileName = Utility.GetUniqueFileName(Image.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploads, fileName);
                Image.CopyTo(new FileStream(filePath, FileMode.Create));
                Character.AvatarLocation = fileName; // Set the file name
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
