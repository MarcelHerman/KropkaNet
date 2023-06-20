using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class StworzDruzyneModel : PageModel
    {
        [BindProperty]
        public Druzyna newDruzyna { get; set; } 
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DBDruzyna database = new DBDruzyna();
            database.Dodaj(newDruzyna);
            return RedirectToPage("/Index");
        }
    }
}
