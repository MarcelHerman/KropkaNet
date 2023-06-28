using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using ProjektTurnieju.DBActions;

namespace ProjektTurnieju.Pages.Organizator
{
    public class DeleteTurniejModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Turniej turniej = new Turniej();
        public void OnGet()
        {
            DBTurniej database = new DBTurniej();
            turniej = database.getOne(Id);
        }

        public IActionResult OnPost()
        {
            if (Id == 1)
            {

                return RedirectToPage("/Blad");
            }
            DBTurniej database = new DBTurniej();
            database.Usun(turniej, Id);
            return RedirectToPage("/Organizator/ListaTurnieji");
        }
    }
}