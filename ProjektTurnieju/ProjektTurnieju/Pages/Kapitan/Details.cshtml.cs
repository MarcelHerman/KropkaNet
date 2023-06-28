using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class DetailsModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public DetailsModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }

      public Druzyna Druzyna { get; set; } = default!;
       public string nickKapitana { get; set; }

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
                DBUzytkownik database = new DBUzytkownik();
                Druzyna = druzyna;
                nickKapitana = database.getOne(Druzyna.IdKapitanaDruzyny).Nick;
            }
            return Page();
        }
    }
}
