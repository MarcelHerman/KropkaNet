using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using ProjektTurnieju.DBActions;

namespace ProjektTurnieju.Organizator
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Uzytkownik uzytkownik = new Uzytkownik();
        public void OnGet()
        {
            DBUzytkownik database = new DBUzytkownik();
            uzytkownik = database.getOne(Id);

        }

        public IActionResult OnPost()
        {
            Console.WriteLine(uzytkownik.ToString());
            DBUzytkownik database = new DBUzytkownik();
            database.Usun(uzytkownik, Id);
            return RedirectToPage("/Organizator/ListaZawodnikow");
        }
    }
}