using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GPFC_Management.Pages.Teams
{
    public class AddPlayerModel : PageModel
    {
        private readonly ILogger<AddPlayerModel> _logger;
        private readonly GPFCContext _context;
        [BindProperty]
        public Player Player { get; set; } = default!;
        public SelectList TeamsDropDown { get; set; } = default!;

        public AddPlayerModel(GPFCContext context, ILogger<AddPlayerModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            TeamsDropDown = new SelectList(_context.Teams.ToList(), "TeamId", "TeamName");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Players.Add(Player);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
