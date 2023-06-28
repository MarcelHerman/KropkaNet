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
using ProjektTurnieju.Migrations;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class DodajZawodnikowModel : PageModel
    {
		private readonly ProjektTurnieju.Data.TurniejDBContext _context;

		public DodajZawodnikowModel(ProjektTurnieju.Data.TurniejDBContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Druzyna Druzyna { get; set; } = default!;

		public int IdKapitana { get; set; }

		public List<Uzytkownik> zawodnikList;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			DBUzytkownik database = new DBUzytkownik();
			zawodnikList = database.getList();

			if (id == null || _context.Druzyny == null)
			{
				return NotFound();
			}

			var druzyna = await _context.Druzyny.FirstOrDefaultAsync(m => m.Id == id);
			if (druzyna == null)
			{
				return NotFound();
			}
			Druzyna = druzyna;
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			IdKapitana = Int32.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
			Druzyna.IdKapitanaDruzyny = IdKapitana;

			Druzyna.Zawodnicy.Add(zawodnikList.FirstOrDefault(m => m.Id == id));
			zawodnikList.FirstOrDefault(m => m.Id == id).CzyMaDruzyne = true;

			_context.Attach(Druzyna).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DruzynaExists(Druzyna.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("/Kapitan/DodajZawodnikow", Druzyna);
		}

		private bool DruzynaExists(int id)
		{
			return (_context.Druzyny?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}

