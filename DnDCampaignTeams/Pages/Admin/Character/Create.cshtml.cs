using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DnDCampaignTeams;
using DnDCampaignTeams.Models;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DnDCampaignTeams.Pages.Admin.Character
{
    public class CreateModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;
        private readonly ILogger<CreateModel> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateModel(DnDCampaignTeams.DnDCampaignTeamsContext context, ILogger<CreateModel> logger, IHostingEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _hostingEnvironment = environment;
        }

        public IActionResult OnGet()
        {
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "FirstName");
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Models.Character Character { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var player = _context.Players.Where(x => x.Id == Character.PlayerId).SingleOrDefault();
            if(player == null)
            {
                _logger.LogError("Player select list allowed user to select a player that doesn't exist.");
                throw new InvalidDataException();
            }

            Character.Player = player;

            if(Character.CampaignId != null)
            {
                var campaign = _context.Campaigns.Where(x => x.Id == Character.CampaignId).SingleOrDefault();
                if(campaign == null)
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

            _context.Characters.Add(Character);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}