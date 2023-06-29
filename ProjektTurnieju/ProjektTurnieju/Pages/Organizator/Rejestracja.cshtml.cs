using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using ProjektTurnieju.DBActions;
using Microsoft.AspNetCore.Identity;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProjektTurnieju
{
    public class RejestracjaModel : PageModel
    {
		[BindProperty]
		public Uzytkownik newUzytkownik { get; set; }
		[BindProperty]
		public string potwierdzHaslo { get; set; }
		public List<Uzytkownik> uzytkownikList { get; set; }
		public void OnGet()
        {
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
			database.Dodaj(newUzytkownik);
			
			return RedirectToPage("/Organizator/ListaUzytkownikow");
		}
	}
}
