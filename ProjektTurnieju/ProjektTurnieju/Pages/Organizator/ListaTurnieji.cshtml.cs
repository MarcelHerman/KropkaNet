using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class ListaTurniejiModel : PageModel
    {
        private readonly TurniejDBContext _context;

        public ListaTurniejiModel(TurniejDBContext context)
        {
            _context = context;
        }

        public IList<Turniej> Turniej { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Turniej != null)
            {
                Turniej = await _context.Turniej.ToListAsync();
            }
        }
    }
}
