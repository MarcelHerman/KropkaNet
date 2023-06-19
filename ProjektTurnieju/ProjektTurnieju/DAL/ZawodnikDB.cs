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
        public string Save()
        {
            return JsonSerializer.Serialize(zawodnicy);
        }
        private int GetNextId()
        {
            if (zawodnicy.Count == 0)
            {
                return 0;
            }
            int lastID = zawodnicy[zawodnicy.Count - 1].Id;
            int newID = lastID + 1;
            return newID;
        }
        public void Create(Zawodnik p)
        {
            p.Id = GetNextId();
            zawodnicy.Add(p);
        }
        public Zawodnik GetZawodnik(int id)
        {
            Zawodnik p1 = zawodnicy.Find(p => p.Id == id);
            return p1;
        }
        public void Edit(Zawodnik newZawodnik)
        {
            Zawodnik p1 = zawodnicy.Find(p => p.Id == newZawodnik.Id);
            p1.Imie = newZawodnik.Imie;
            p1.Nazwisko = newZawodnik.Nazwisko;
            p1.Nick = newZawodnik.Nick;
            p1.CzyMaDruzyne = newZawodnik.CzyMaDruzyne;
        }
        public void Delete(int id)
        {
            Zawodnik p1 = zawodnicy.SingleOrDefault(p => p.Id == id); //wyszukanie pierwszego elementu spełniającego kryteria
            if (p1 != null)
            {
                zawodnicy.Remove(p1);
            }
        }
    }
}
