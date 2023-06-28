using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
    public class StronaDruzynyModel : PageModel
    {
		TurniejDBContext _context = new TurniejDBContext();

		public IList<Druzyna> Druzyny { get;set; } = default!;
        public Druzyna ?druzynaKapitana { get;set; } = null;
        public string IdKapitana { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            IdKapitana = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_context.Druzyny != null)
            {
                Druzyny = await _context.Druzyny.ToListAsync();
                foreach (Druzyna druzyna in Druzyny)
                {
                    if(IdKapitana == druzyna.IdKapitanaDruzyny.ToString())
                    {
                        druzynaKapitana = druzyna;
                        break;
                    }
                }
                
                if (druzynaKapitana == null)
                {
					return this.RedirectToPage("CreateDruzyna");
				}
            }
            else
            {
                return this.RedirectToPage("CreateDruzyna");
            }
            return this.RedirectToPage("DetailsDruzyna",druzynaKapitana);
        }
    }
}
