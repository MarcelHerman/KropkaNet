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
			LoadZawodnikDB();
			zawodnikList = zawodnikDB.List();
            SaveZawodnikDB();
        }
	}
}
