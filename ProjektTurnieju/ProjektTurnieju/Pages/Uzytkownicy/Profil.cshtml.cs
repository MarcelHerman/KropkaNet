using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using System.Security.Claims;
using ProjektTurnieju.DBActions;

namespace ProjektTurnieju.Pages.Uzytkownicy
{
    public class ProfilModel : PageModel
    {
        [BindProperty]
        public Uzytkownik uzytkownik { get; set; }
        public int idZawodnika { get; set; }
        public void OnGet()
        {
            idZawodnika = Int32.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            DBUzytkownik database = new DBUzytkownik();
            uzytkownik = database.getOne(idZawodnika);

        }
    }
}
