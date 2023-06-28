using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.TurniejKat
{
    public class DeleteModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public DeleteModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Turniej Turniej { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Turniej == null)
            {
                return NotFound();
            }

            var turniej = await _context.Turniej.FirstOrDefaultAsync(m => m.Id == id);

            if (turniej == null)
            {
                return NotFound();
            }
            else 
            {
                Turniej = turniej;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Turniej == null)
            {
                return NotFound();
            }
            var turniej = await _context.Turniej.FindAsync(id);

            if (turniej != null)
            {
                Turniej = turniej;
                _context.Turniej.Remove(Turniej);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
