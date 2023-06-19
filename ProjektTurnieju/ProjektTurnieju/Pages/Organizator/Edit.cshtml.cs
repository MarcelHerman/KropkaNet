using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Uzytkownik newUzytkownik { get; set; }
        [BindProperty]
		public string potwierdzHaslo { get; set; }
		public void OnGet()
        {
			DBUzytkownik database = new DBUzytkownik();
			newUzytkownik = database.getOne(Id);
		}
        public IActionResult OnPost()
        {
			if (!newUzytkownik.Haslo.Equals(potwierdzHaslo))
			{
				return Page();
			}
			DBUzytkownik database = new DBUzytkownik();
            database.Zmodyfikuj(newUzytkownik, Id);
            return RedirectToPage("/Organizator/ListaUzytkownikow");
        }
    }
}
