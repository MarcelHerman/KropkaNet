using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ProjektTurnieju.DAL;
using ProjektTurnieju.Models;

namespace ProjektTurnieju
{
	public class IndexModel : MyPageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public IConfiguration _configuration { get; }

		public IndexModel(IConfiguration configuration,ILogger<IndexModel> logger)
		{
			_logger = logger;
			_configuration = configuration;
		}
		public List<Ogloszenie> ogloszenieList;
		public void OnGet()
		{
			LoadOgloszenieDB();
			ogloszenieList = ogloszenieDB.List();
			string BazaTurnieju_connection_string = _configuration.GetConnectionString("BazaTurnieju");
		}
	}
}