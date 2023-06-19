using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel (ILogger<IndexModel> logger)
		{
			_logger = logger;
		}
		public List<Ogloszenie> ogloszenieList;
		public void OnGet()
		{
			DBOgloszenia dBOgloszenia = new DBOgloszenia();
			ogloszenieList = dBOgloszenia.getList();
		}
	}
}