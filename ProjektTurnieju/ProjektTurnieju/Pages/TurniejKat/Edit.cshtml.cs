using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.TurniejKat
{
    public class EditModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public EditModel(ProjektTurnieju.Data.TurniejDBContext context)
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

            var turniej =  await _context.Turniej.FirstOrDefaultAsync(m => m.Id == id);
            if (turniej == null)
            {
                return NotFound();
            }
            Turniej = turniej;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Turniej).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurniejExists(Turniej.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TurniejExists(int id)
        {
          return (_context.Turniej?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
