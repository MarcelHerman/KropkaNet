using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class CreateModel : PageModel
    {
		TurniejDBContext _context = new TurniejDBContext();

		public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Druzyna Druzyna { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Druzyna.IdKapitanaDruzyny = obecny tworca;
           
            if (!ModelState.IsValid || _context.Druzyny == null || Druzyna == null)
            {
                return Page();
            }

            _context.Druzyny.Add(Druzyna);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
