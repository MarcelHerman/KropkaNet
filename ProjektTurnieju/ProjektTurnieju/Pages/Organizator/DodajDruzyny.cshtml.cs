using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class DodajDruzynyModel : PageModel
    {
        public List<Druzyna> druzynaList;
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public DodajDruzynyModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Turniej Turniej { get; set; }
        public async Task OnGetAsync(int? id)
        {
            var turniej = await _context.Turniej.FirstOrDefaultAsync(m => m.Id == id);

            Turniej = turniej;

            DBDruzyna database = new DBDruzyna();
            druzynaList = database.getList();
        }
    }
}
