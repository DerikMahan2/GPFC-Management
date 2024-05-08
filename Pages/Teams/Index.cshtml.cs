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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGPFC.Models.GPFCContext _context;

        public IndexModel(RazorPagesGPFC.Models.GPFCContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Team = await _context.Teams.ToListAsync();
        }
    }
}
