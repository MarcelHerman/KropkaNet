using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using ProjektTurnieju.DAL;

namespace ProjektTurnieju.Organizator
{
    public class DeleteModel : MyPageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Zawodnik zawodnik { get; set; }
        public void OnGet()
        {
            LoadZawodnikDB();
            zawodnik = zawodnikDB.GetZawodnik(Id);
        }

        public IActionResult OnPost()
        {
            LoadZawodnikDB();
            zawodnikDB.Delete(Id);
            SaveZawodnikDB();
            return RedirectToPage("/Organizator/ListaZawodnikow");
        }
    }
}