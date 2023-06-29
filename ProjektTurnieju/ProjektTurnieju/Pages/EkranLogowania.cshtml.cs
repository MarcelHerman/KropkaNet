using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ProjektTurnieju.DBActions;
using Microsoft.AspNetCore.Identity;

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
                    new Claim(ClaimTypes.NameIdentifier, uzytkownik.Id.ToString()),
                    new Claim(ClaimTypes.Name, uzytkownik.Login),
                    new Claim(ClaimTypes.Hash, uzytkownik.Haslo),
                    new Claim(ClaimTypes.Role, uzytkownik.Rola.ToString())
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
            if (username == "admin" && password == "password")
            {
                return true;
            }
            else
            {
                DBUzytkownik dbUzytkownik = new DBUzytkownik();
                List<Uzytkownik> listaUzytkownikow = dbUzytkownik.getList();
                var passwordHasher = new PasswordHasher<string>();  

                foreach (Uzytkownik uzytkownikListy in listaUzytkownikow)
                {
                    if (uzytkownikListy.Login == username
                        && passwordHasher.VerifyHashedPassword(uzytkownikListy.Login, uzytkownikListy.Haslo, password) == PasswordVerificationResult.Success)
                    {
                        uzytkownik.Id = uzytkownikListy.Id;
                        uzytkownik.Rola = uzytkownikListy.Rola;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
