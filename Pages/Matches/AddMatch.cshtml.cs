using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging; // Ensure ILogger is available
using RazorPagesGPFC.Models;
using System.Threading.Tasks;

namespace GPFC_Management.Pages.Matches
{
    public class AddMatchModel : PageModel
    {
        private readonly GPFCContext _context;
        private readonly ILogger<AddMatchModel> _logger; // Logger to log information or errors

        public AddMatchModel(GPFCContext context, ILogger<AddMatchModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Match Match { get; set; }
        public SelectList Teams { get; set; }

        public void OnGet()
        {
            Teams = new SelectList(_context.Teams, "TeamId", "TeamName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Log the HomeTeamId and AwayTeamId at the start of the method
            _logger.LogInformation("Posting new match: HomeTeamId={HomeTeamId}, AwayTeamId={AwayTeamId}", Match.HomeTeamId, Match.AwayTeamId);

            if (!ModelState.IsValid)
            {
                // Log each error or handle them as needed
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError("Validation error: {ErrorMessage}", error.ErrorMessage);
                    }
                }

                // Repopulate the dropdowns if needed
                Teams = new SelectList(_context.Teams, "TeamId", "TeamName");
                return Page();
            }

            try
            {
                _context.Matches.Add(Match);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save the match");
                ModelState.AddModelError(string.Empty, "An error occurred saving the match.");
                return Page();
            }
        }
    }
}
