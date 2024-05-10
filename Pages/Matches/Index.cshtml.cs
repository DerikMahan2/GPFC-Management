using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages.Matches
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGPFC.Models.GPFCContext _context;

        public IndexModel(RazorPagesGPFC.Models.GPFCContext context)
        {
            _context = context;
        }

        public IList<Match> Match { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Match = await _context.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam).ToListAsync();
        }
    }
}
