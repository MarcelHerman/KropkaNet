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
		private readonly TurniejDBContext _context;

		public CreateTurniejModel(TurniejDBContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Turniej newTurniej { get; set; }

		public List<Druzyna> DruzynyList { get; set; }

		public void OnGet()
		{
			PopulateDruzynyList();
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid == false)
			{
				PopulateDruzynyList();
				return Page();
			}
			
			DBTurniej database = new DBTurniej();
			database.Dodaj(newTurniej);

			return RedirectToPage("/Organizator/ListaTurnieji");
		}

		private void PopulateDruzynyList()
		{
			var druzyny = _context.Druzyny;
			DruzynyList = new List<Druzyna>();

			foreach (var druzyna in druzyny)
			{
				DruzynyList.Add(new Druzyna
				{
					Id = druzyna.Id,
					NazwaDruzyny = druzyna.NazwaDruzyny
				});
			}
		}
	}
}
