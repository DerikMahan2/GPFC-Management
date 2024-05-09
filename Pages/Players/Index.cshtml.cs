using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages.Players
{
    // Class to handle the display of players on the Index page.
    public class IndexModel : PageModel
    {
        private readonly GPFCContext _context; // Database context for GPFC.

        public IList<Player> Players { get; set; } // List to store player data.

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } // Search string to filter players.

        [BindProperty(SupportsGet = true)]
        public string PlayerSort { get; set; } // Sort order for displaying players.

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; } // Current filter applied to player list.

        // Constructor to initialize the database context.
        public IndexModel(GPFCContext context)
        {
            _context = context;
        }

        // Asynchronous method to handle GET request with paging and sorting.
        public async Task OnGetAsync(int? currentPage, string sortOrder)
        {
            CurrentFilter = SearchString; // Set the current filter to search string.
            PlayerSort = sortOrder; // Set the sorting order.

            IQueryable<Player> playerIQ = from p in _context.Players select p; // Query to select all players.

            if (!string.IsNullOrEmpty(SearchString)) // Apply search filter if provided.
            {
                playerIQ = playerIQ.Where(p => p.Name.Contains(SearchString) || p.Team.TeamName.Contains(SearchString));
            }

            switch (sortOrder) // Apply sorting based on sort order.
            {
                case "name_desc":
                    playerIQ = playerIQ.OrderByDescending(p => p.Name);
                    break;
                case "Age":
                    playerIQ = playerIQ.OrderBy(p => p.Age);
                    break;
                case "age_desc":
                    playerIQ = playerIQ.OrderByDescending(p => p.Age);
                    break;
                default:
                    playerIQ = playerIQ.OrderBy(p => p.Name);
                    break;
            }

            int PageSize = 10; // Number of players per page.
            int TotalPlayers = await playerIQ.CountAsync(); // Total number of filtered players.
            int CurrentPage = currentPage.HasValue ? currentPage.Value : 1; // Current page number.

            Players = await playerIQ.Include(p => p.Team) // Include team data for each player.
                .Skip((CurrentPage - 1) * PageSize) // Skip players for previous pages.
                .Take(PageSize) // Take only the number of players for the current page.
                .ToListAsync(); // Execute the query and convert to list.
        }
    }
}
