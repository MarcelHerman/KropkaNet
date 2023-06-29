using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;
using System.Data;

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
        public static List<Uzytkownik> zawodnikList;
        public void OnGet()
		{
			string sql = "SELECT * FROM Ogloszenia";

			string BazaTurnieju_connection_string = _configuration.GetConnectionString("BazaTurnieju");
			SqlConnection con = new SqlConnection(BazaTurnieju_connection_string);

            DBUzytkownik database = new DBUzytkownik();
            zawodnikList = database.getList();

			SqlCommand initOrganizator = new SqlCommand("initialOrganizator", con);
			initOrganizator.CommandType = CommandType.StoredProcedure;

            var passwordHasher = new PasswordHasher<string>();
            Uzytkownik uzytkownik = new Uzytkownik();
			uzytkownik.Haslo = "haslo";
			uzytkownik.Login = "login";
			var password = passwordHasher.HashPassword(uzytkownik.Login, uzytkownik.Haslo);

            SqlParameter name_SqlParam = new SqlParameter("@haslo", SqlDbType.NVarChar, 4000);
            name_SqlParam.Value = password;
			initOrganizator.Parameters.Add(name_SqlParam);

            SqlCommand cmd = new SqlCommand(sql, con);
			con.Open();

			if (zawodnikList.Count == 0)
			{
				int numAff = initOrganizator.ExecuteNonQuery();
			}
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