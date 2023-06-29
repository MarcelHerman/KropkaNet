using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.Migrations;
using ProjektTurnieju.Models;


namespace ProjektTurnieju.Pages.Organizator
{
    public class DeleteTurniejModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public DeleteTurniejModel(ProjektTurnieju.Data.TurniejDBContext context)
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

            var turniej = await _context.Turniej.Include(Turniej => Turniej.Druzyny).FirstOrDefaultAsync(m => m.Id == id);

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
            var turniej = await _context.Turniej.Include(Turniej => Turniej.Druzyny).FirstOrDefaultAsync(m => m.Id == id);

            if (turniej != null)
            {
                Turniej = turniej;

                foreach (var druzyna in Turniej.Druzyny)
                {
                    Turniej.Druzyny.Remove(druzyna);
                }

                _context.Turniej.Remove(Turniej);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Organizator/ListaTurnieji");
        }
    }
}