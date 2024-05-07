using GPFC_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GPFC_Management.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly GPFCContext _context;

    public IList<Team> Teams { get; set; }

    public IndexModel(ILogger<IndexModel> logger, GPFCContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        Teams = _context.Teams.ToList();
    }
}
