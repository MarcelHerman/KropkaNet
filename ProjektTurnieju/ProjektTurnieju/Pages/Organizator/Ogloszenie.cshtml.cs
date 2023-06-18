using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.Models;
using ProjektTurnieju.DAL;

namespace ProjektTurnieju.Pages
{
    public class OgloszenieModel : MyPageModel
    {
        [BindProperty]
        public Ogloszenie newOgloszenie { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            LoadOgloszenieDB();
            ogloszenieDB.Create(newOgloszenie);
            SaveOgloszenieDB();
            return RedirectToPage("Index");
        }
    }
}
