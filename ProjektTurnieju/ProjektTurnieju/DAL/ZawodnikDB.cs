using System.Text.Json;
using System.Text.Json.Serialization;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.DAL
{
	public class ZawodnikDB
	{
		private List<Zawodnik> zawodnicy;
		public void Load(string jsonZawodnicy)
		{
			if (jsonZawodnicy == null)
			{
				zawodnicy = Zawodnik.GetZawodnicy();
			}
			else
			{
				zawodnicy = JsonSerializer.Deserialize<List<Zawodnik>>(jsonZawodnicy);
			}
		}
		public List<Zawodnik> List()
		{
			return zawodnicy;
		}
	}
}
