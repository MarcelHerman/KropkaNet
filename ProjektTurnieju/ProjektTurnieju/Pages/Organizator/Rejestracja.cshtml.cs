using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using ProjektTurnieju.DBActions;

namespace ProjektTurnieju
{
    public class RejestracjaModel : PageModel
    {
		[BindProperty]
		public Uzytkownik newUzytkownik { get; set; }
		public void OnGet()
        {
        }
		public IActionResult OnPost()
		{
			DBUzytkownik database = new DBUzytkownik();
			database.Dodaj(newUzytkownik);
			
			return RedirectToPage("/Organizator/ListaUzytkownikow");
		}
	}
}
