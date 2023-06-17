using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.DAL;

namespace ProjektTurnieju.Models
{
	public class MyPageModel : PageModel
	{
		public ZawodnikDB zawodnikDB;
		public MyPageModel()
		{
			zawodnikDB = new ZawodnikDB();
		}
		public void LoadDB()
		{
			string jsonProductDB = HttpContext.Session.GetString("jsonProductDB");
			zawodnikDB.Load(jsonProductDB);
		}
	}
}
