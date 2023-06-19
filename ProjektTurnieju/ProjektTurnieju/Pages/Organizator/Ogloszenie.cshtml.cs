using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            return RedirectToPage("/Index");
        }
    }
}
