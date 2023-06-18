using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;

namespace ProjektTurnieju
{
    public class RejestracjaModel : MyPageModel
    {
		[BindProperty]
		public Zawodnik newZawodnik { get; set; }
		public void OnGet()
        {
        }
		public IActionResult OnPost()
		{
			LoadZawodnikDB();
			zawodnikDB.Create(newZawodnik);
			SaveZawodnikDB();
			return RedirectToPage("/Organizator/ListaZawodnikow");
		}
	}
}
