using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ProjektTurnieju.Pages
{
    public class EkranLogowaniaModel : PageModel
    {
        [BindProperty]
        public Uzytkownik uzytkownik { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (IsValidUser(uzytkownik.Login, uzytkownik.Haslo))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, uzytkownik.Login),
                    new Claim(ClaimTypes.Hash, uzytkownik.Haslo)
                };

                var identity = new ClaimsIdentity(claims, "CookieAuthentication");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuthentication", principal);

                return RedirectToPage("/Index");
            }
            return Page();
        }

        private bool IsValidUser(string username, string password)
        {
            // Przyk³adowa logika uwierzytelniania, trzeba zrobiæ ¿eby z bazy danych bra³o
            if (username == "admin" && password == "password")
            {
                return true;
            }

            return false;
        }
    }
}
