using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju
{
    public class OgloszenieModel : PageModel
    {
        [BindProperty]
        public Ogloszenie newOgloszenie { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
			DBOgloszenia database = new DBOgloszenia();
			database.Dodaj(newOgloszenie);

			return RedirectToPage("/Index");
        }
    }
}
