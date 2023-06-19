using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ProjektTurnieju.Models;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis;
using ProjektTurnieju.DBActions;

namespace ProjektTurnieju
{
    public class ListaUzytkownikowModel : PageModel
    {
		public List<Uzytkownik> zawodnikList;
        public void OnGet()
		{
			DBUzytkownik database = new DBUzytkownik();
			zawodnikList = database.getList();
        }
	}
}
