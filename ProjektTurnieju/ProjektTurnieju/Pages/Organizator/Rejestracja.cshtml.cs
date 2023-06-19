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
		[BindProperty]
		public string potwierdzHaslo { get; set; }
		public void OnGet()
        {
        }
		public IActionResult OnPost()
		{
			if (ModelState.IsValid == false)
				return Page();
			if (!newUzytkownik.Haslo.Equals(potwierdzHaslo))
			{
				return Page();
			}
			DBUzytkownik database = new DBUzytkownik();
			database.Dodaj(newUzytkownik);
			
			return RedirectToPage("/Organizator/ListaUzytkownikow");
		}
	}
}
