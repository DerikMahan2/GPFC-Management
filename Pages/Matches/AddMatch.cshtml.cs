using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesGPFC.Models;
using System;
using System.Threading.Tasks;

public class AddMatchModel : PageModel
{
    private readonly GPFCContext _context;

    public AddMatchModel(GPFCContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Match Match { get; set; }

    public SelectList Teams { get; set; }

    public void OnGet()
    {
        Teams = new SelectList(_context.Teams, "TeamId", "TeamName");
    }

    public IActionResult OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Teams = new SelectList(_context.Teams, "TeamId", "TeamName"); // Repopulate teams if there's an error
            return Page();
        }

        _context.Matches.Add(Match);
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}
