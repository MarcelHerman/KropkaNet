using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class CreateTurniejModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public CreateTurniejModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Turniej Turniej { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Turniej == null || Turniej == null)
            {
                return Page();
            }

            _context.Turniej.Add(Turniej);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
