using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektTurnieju.Data;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class CreateTurniejModel : PageModel
    {
		[BindProperty]
		public Turniej newTurniej { get; set; }

		public void OnGet()
		{
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid == false)
				return Page();
			
			DBTurniej database = new DBTurniej();
			database.Dodaj(newTurniej);

			return RedirectToPage("/Organizator/ListaTurnieji");
		}
	}
}
