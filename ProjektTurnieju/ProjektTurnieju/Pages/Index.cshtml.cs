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
		public IConfiguration _configuration { get; }
		public List<Ogloszenie> ogloszenieList;

		public IndexModel (ILogger<IndexModel> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}
		public void OnGet()
		{
			string sql = "SELECT * FROM Ogloszenia";

			string BazaTurnieju_connection_string = _configuration.GetConnectionString("BazaTurnieju");
			SqlConnection con = new SqlConnection(BazaTurnieju_connection_string);

			SqlCommand cmd = new SqlCommand(sql, con);
			con.Open();
			SqlDataReader reader = cmd.ExecuteReader();

			ogloszenieList = new List<Ogloszenie>();
			Ogloszenie ogloszenie;
			while(reader.Read())
			{
				ogloszenie = new Ogloszenie();
				ogloszenie.Tytul = reader.GetValue(1).ToString();
				ogloszenie.Tresc = reader.GetValue(2).ToString();
				ogloszenie.DataDodania = (DateTime)reader.GetValue(3);
				ogloszenieList.Add(ogloszenie);
			}
			con.Close();
		}
	}
}