using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Migrations;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Kapitan
{
	public class DodajZawodnikowModel : PageModel
	{
		public List<Uzytkownik> zawodnikList;
		[BindProperty]
		public int ?_idDruzyny { get; set; }
		public void OnGet(int ?idDruzyny)
		{
			_idDruzyny = idDruzyny;
			DBUzytkownik database = new DBUzytkownik();
			zawodnikList = database.getList();
		}
	}
}

