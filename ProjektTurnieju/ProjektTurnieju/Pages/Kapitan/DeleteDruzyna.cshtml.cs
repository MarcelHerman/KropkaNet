using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class DeleteDruzynaModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public DeleteDruzynaModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Druzyna Druzyna { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Druzyny == null)
            {
                return NotFound();
            }

            var druzyna = await _context.Druzyny.FirstOrDefaultAsync(m => m.Id == id);

            if (druzyna == null)
            {
                return NotFound();
            }
            else 
            {
                Druzyna = druzyna;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Druzyny == null)
            {
                return NotFound();
            }
            var druzyna = await _context.Druzyny.FindAsync(id);

            if (druzyna != null)
            {
                Druzyna = druzyna;
                _context.Druzyny.Remove(Druzyna);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
