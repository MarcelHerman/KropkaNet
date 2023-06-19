using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjektTurnieju.Models;

namespace ProjektTurnieju
{
	public class IndexModel : PageModel
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
			string BazaTurnieju_connection_string = _configuration.GetConnectionString("BazaTurnieju");
		}
	}
}