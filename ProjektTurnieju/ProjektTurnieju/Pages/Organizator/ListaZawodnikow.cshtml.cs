using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ProjektTurnieju.Models;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis;

namespace ProjektTurnieju
{
    public class ListaZawodnikowModel : MyPageModel
    {
		public List<Zawodnik> zawodnikList;
		public IConfiguration _configuration { get; }

		public ListaZawodnikowModel (IConfiguration configuration)
		{
			_configuration = configuration;

        }
        public void OnGet()
		{

            string sql = "SELECT * FROM Zawodnicy";

            string BazaTurnieju_connection_string = _configuration.GetConnectionString("BazaTurnieju");
            SqlConnection con = new SqlConnection(BazaTurnieju_connection_string);

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            zawodnikList = new List<Zawodnik>();
            Zawodnik z1 = new Zawodnik();

            zawodnikList.Add(z1);
            reader.Read();
            zawodnikList[0].Id = (int)reader.GetValue(0);
            zawodnikList[0].Imie = reader.GetValue(1).ToString();
            zawodnikList[0].Nazwisko = reader.GetValue(2).ToString();
            zawodnikList[0].Nick = reader.GetValue(3).ToString();
        }
	}
}
