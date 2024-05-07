using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GPFC_Management.Models;

namespace GPFC_Management.Pages_Players
{
    public class IndexModel : PageModel
    {
        private readonly GPFC_Management.Models.GPFCContext _context;

        public IndexModel(GPFC_Management.Models.GPFCContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Players
                .Include(p => p.Team).ToListAsync();
        }
    }
}
