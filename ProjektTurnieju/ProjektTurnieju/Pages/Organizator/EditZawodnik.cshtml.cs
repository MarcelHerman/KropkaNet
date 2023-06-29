using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class EditZawodnikModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Uzytkownik newUzytkownik { get; set; }
        [BindProperty]
		public string potwierdzHaslo { get; set; }
        public List<Uzytkownik> uzytkownikList { get; set; }
		public void OnGet()
        {
			DBUzytkownik database = new DBUzytkownik();
			newUzytkownik = database.getOne(Id);
            newUzytkownik.Haslo = null;
		}
        public IActionResult OnPost()
        {
			DBUzytkownik database = new DBUzytkownik();
			uzytkownikList = database.getList();

			if (ModelState.IsValid == false)
				return Page();
			if (!newUzytkownik.Haslo.Equals(potwierdzHaslo))
			{
				return Page();
			}
			foreach (Uzytkownik uzytkownik in uzytkownikList)
			{
				if (uzytkownik.Login == newUzytkownik.Login)
					return Page();
			}
			var passwordHasher = new PasswordHasher<string>();

            newUzytkownik.Haslo = passwordHasher.HashPassword(newUzytkownik.Login, newUzytkownik.Haslo);

            database.Zmodyfikuj(newUzytkownik, Id);
            return RedirectToPage("/Organizator/ListaUzytkownikow");
        }
    }
}
