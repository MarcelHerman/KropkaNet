using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class EditTurniejModel : PageModel
    {
		private readonly ProjektTurnieju.Data.TurniejDBContext _context;

		public EditTurniejModel(ProjektTurnieju.Data.TurniejDBContext context)
		{
			_context = context;
		}

		public Turniej newTurniej { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Druzyny == null)
			{
				return NotFound();
			}

			var turniej = await _context.Turniej.Include(Turniej => Turniej.Druzyny).FirstOrDefaultAsync(m => m.Id == id);
			if (turniej == null)
			{
				return NotFound();
			}
			else
			{
				DBDruzyna database = new DBDruzyna();
				newTurniej = turniej;
			}
			return Page();
		}
	}
}
