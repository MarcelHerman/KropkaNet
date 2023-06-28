using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class CreateDruzynaModel : PageModel
    {
		TurniejDBContext _context = new TurniejDBContext();

        [BindProperty]
        public Druzyna Druzyna { get; set; } = default!;

        public int IdKapitana { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            IdKapitana = Int32.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Druzyna.IdKapitanaDruzyny = IdKapitana;

            if (!ModelState.IsValid || Druzyna == null)
            {
                return Page();
            }

            _context.Druzyny.Add(Druzyna);
            await _context.SaveChangesAsync();

            return RedirectToPage("StronaDruzyny");
        }
    }
}
