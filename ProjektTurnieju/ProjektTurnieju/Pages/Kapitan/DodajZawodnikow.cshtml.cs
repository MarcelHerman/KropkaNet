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

namespace ProjektTurnieju.Pages.Kapitan
{
	public class DodajZawodnikowModel : PageModel
	{
		public List<Uzytkownik> zawodnikList;
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public DodajZawodnikowModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }
        [BindProperty]
		public Druzyna Druzyna { get; set; }
		public async Task OnGetAsync(int ?id)
		{
            var druzyna = await _context.Druzyny.FirstOrDefaultAsync(m => m.Id == id);
			
			Druzyna = druzyna;

			DBUzytkownik database = new DBUzytkownik();
			zawodnikList = database.getList();
		}
	}
}

