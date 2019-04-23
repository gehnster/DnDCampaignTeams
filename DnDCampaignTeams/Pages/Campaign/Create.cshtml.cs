using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DnDCampaignTeams;
using DnDCampaignTeams.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DnDCampaignTeams.Pages.Campaign
{
    public class CreateModel : PageModel
    {
        private readonly DnDCampaignTeams.DnDCampaignTeamsContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateModel(DnDCampaignTeams.DnDCampaignTeamsContext context, IHostingEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Campaign Campaign { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                if(!Image.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Image", "File needs to be an image.");
                    return Page();
                }

                var fileName = Utility.GetUniqueFileName(Image.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploads, fileName);
                Image.CopyTo(new FileStream(filePath, FileMode.Create));
                Campaign.LogoLocation = fileName; // Set the file name
            }

            _context.Campaigns.Add(Campaign);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}