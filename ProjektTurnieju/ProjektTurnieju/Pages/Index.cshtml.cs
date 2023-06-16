using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ProjektTurnieju.Pages
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

		public void OnGet()
		{
			string BazaTurnieju_connection_string = _configuration.GetConnectionString("BazaTurnieju");
		}
	}
}