using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesGPFC.Models.GPFCContext _context;

        public DetailsModel(RazorPagesGPFC.Models.GPFCContext context)
        {
            _context = context;
        }

        public Team Team { get; set; } = default!;

        public int PlayerIdToDelete { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.Include(t => t.Players).FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }
            else
            {
                Team = team;
            }
            return Page();
        }

        public IActionResult OnPostDeletePlayer(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var Course = _context.Players.FirstOrDefault(c => c.PlayerId == PlayerIdToDelete);

            if (Course != null)
            {
                _context.Remove(Course);
                _context.SaveChanges();
            }

            Team = _context.Teams.Include(p => p.Players).First(p => p.TeamId == id);

            return Page();
        }
    }
}
