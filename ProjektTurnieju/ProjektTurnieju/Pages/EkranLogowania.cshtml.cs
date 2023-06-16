using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages
{
    public class EkranLogowaniaModel : PageModel
    {
        [BindProperty]
        public Uzytkownik uzytkownik { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false) 
            {
                return Page();
            }
            return RedirectToPage("StronaGlowna");
        }
    }
}
