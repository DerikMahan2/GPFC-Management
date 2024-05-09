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
    // Class to handle the functionality of the Teams Index page.
    public class IndexModel : PageModel
    {
        private readonly GPFCContext _context;  // Database context for GPFC.

        // Constructor to initialize the database context.
        public IndexModel(GPFCContext context)
        {
            _context = context;
        }

        // List to store team data.
        public IList<Team> Team { get; set; } = default!;

        // Asynchronous method to handle GET request, loads all teams into the Team list.
        public async Task OnGetAsync()
        {
            Team = await _context.Teams.ToListAsync();  // Asynchronously query all teams from the database and convert to list.
        }
    }
}
