using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ProjektTurnieju.Models;

namespace ProjektTurnieju
{
    public class ListaZawodnikowModel : MyPageModel
    {
		public List<Zawodnik> zawodnikList;
		public void OnGet()
		{
			LoadDB();
			zawodnikList = zawodnikDB.List();
		}
	}
}
