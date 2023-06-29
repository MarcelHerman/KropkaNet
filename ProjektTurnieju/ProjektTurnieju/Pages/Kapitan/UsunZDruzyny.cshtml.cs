using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class UsunZDruzynyModel : PageModel
    {
		private readonly ProjektTurnieju.Data.TurniejDBContext _context;

		public UsunZDruzynyModel(ProjektTurnieju.Data.TurniejDBContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Druzyna Druzyna { get; set; } = default!;
		[BindProperty]
		public Uzytkownik Uzytkownik { get; set; } = default!;
		public int IdKapitana { get; set; }
		public async Task<IActionResult> OnGetAsync(int id, int idDruzyny)
		{

			var druzyna = await _context.Druzyny.Include(Druzyna => Druzyna.Zawodnicy).FirstOrDefaultAsync(m => m.Id == idDruzyny);
			var uzytkownik = await _context.Uzytkownicy.FirstOrDefaultAsync(m => m.Id == id);

			Uzytkownik = uzytkownik;
			Druzyna = druzyna;

			IdKapitana = Int32.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

			if(Druzyna.Zawodnicy == null)
			{
				Druzyna.Zawodnicy = new List<Uzytkownik>();
			}
			Druzyna.IdKapitanaDruzyny = IdKapitana;
			Druzyna.Zawodnicy.Remove(Uzytkownik);
			Uzytkownik.CzyMaDruzyne = false;

			_context.Attach(Uzytkownik).State = EntityState.Modified;
			_context.Attach(Druzyna).State = EntityState.Modified;

				await _context.SaveChangesAsync();
			return RedirectToPage("/Kapitan/DetailsDruzyna", Druzyna);
		}

	}
}
