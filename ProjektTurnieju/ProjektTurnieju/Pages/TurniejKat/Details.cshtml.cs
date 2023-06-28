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
    public class DetailsModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public DetailsModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }

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
    }
}
