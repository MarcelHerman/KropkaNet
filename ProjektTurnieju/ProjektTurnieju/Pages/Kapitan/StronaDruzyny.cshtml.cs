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
    public class StronaDruzynyModel : PageModel
    {
		TurniejDBContext _context = new TurniejDBContext();

		public IList<Druzyna> Druzyna { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Druzyny != null)
            {
                Druzyna = await _context.Druzyny.ToListAsync();
            }
        }
    }
}
