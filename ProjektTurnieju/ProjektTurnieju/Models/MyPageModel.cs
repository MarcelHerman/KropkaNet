using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektTurnieju.DAL;

namespace ProjektTurnieju.Models
{
	public class MyPageModel : PageModel
	{
		public ZawodnikDB zawodnikDB;
        public OgloszenieDB ogloszenieDB;
        public MyPageModel()
		{
			zawodnikDB = new ZawodnikDB();
            ogloszenieDB = new OgloszenieDB();

        }
		public void LoadZawodnikDB()
		{
			string jsonZawodnikDB = HttpContext.Session.GetString("jsonZawodnikDB");
			zawodnikDB.Load(jsonZawodnikDB);
		}
        public void SaveZawodnikDB()
        {
            string jsonZawodnikDB = zawodnikDB.Save();
            HttpContext.Session.SetString("jsonZawodnikDB", jsonZawodnikDB);
        }
        public void LoadOgloszenieDB()
        {
            string jsonOgloszenieDB = HttpContext.Session.GetString("jsonOgloszenieDB");
            ogloszenieDB.Load(jsonOgloszenieDB);
        }
        public void SaveOgloszenieDB()
        {
            string jsonOgloszenieDB = ogloszenieDB.Save();
            HttpContext.Session.SetString("jsonOgloszenieDB", jsonOgloszenieDB);
        }
    }
}
