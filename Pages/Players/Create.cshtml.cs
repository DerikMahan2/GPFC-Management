using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GPFC_Management.Models;

namespace GPFC_Management.Pages_Players
{
    public class CreateModel : PageModel
    {
        private readonly GPFC_Management.Models.GPFCContext _context;

        public CreateModel(GPFC_Management.Models.GPFCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamName");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Players.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
