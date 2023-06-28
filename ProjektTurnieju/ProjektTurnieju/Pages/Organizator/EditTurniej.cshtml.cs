using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class EditTurniejModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Turniej newTurniej { get; set; }

        public void OnGet()
        {
            DBTurniej database = new DBTurniej();
            newTurniej = database.getOne(Id);
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();

            DBTurniej database = new DBTurniej();
            database.Zmodyfikuj(newTurniej, Id);
            return RedirectToPage("/Organizator/ListaTurnieji");
        }
    }
}
