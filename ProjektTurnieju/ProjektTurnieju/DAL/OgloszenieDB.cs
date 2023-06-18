using ProjektTurnieju.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjektTurnieju.DAL
{
    public class OgloszenieDB
    {
        private List<Ogloszenie> ogloszenia;
        public void Load(string jsonOgloszenie)
        {
            if (jsonOgloszenie == null)
            {
                ogloszenia = Ogloszenie.GetOgloszenia();
            }
            else
            {
                ogloszenia = JsonSerializer.Deserialize<List<Ogloszenie>>(jsonOgloszenie);
            }
        }
        public List<Ogloszenie> List()
        {
            return ogloszenia;
        }
        public string Save()
        {
            return JsonSerializer.Serialize(ogloszenia);
        }
        private int GetNextId()
        {
            if (ogloszenia.Count == 0)
            {
                return 0;
            }
            int lastID = ogloszenia[ogloszenia.Count - 1].Id;
            int newID = lastID + 1;
            return newID;
        }
        public void Create(Ogloszenie p)
        {
            p.Id = GetNextId();
            ogloszenia.Add(p);
        }
        public Ogloszenie GetZawodnik(int id)
        {
            Ogloszenie p1 = ogloszenia.Find(p => p.Id == id);
            return p1;
        }
        public void Edit(Ogloszenie newOgloszenie)
        {
            Ogloszenie p1 = ogloszenia.Find(p => p.Id == newOgloszenie.Id);
            p1.Tytul = newOgloszenie.Tytul;
            p1.Tresc = newOgloszenie.Tresc;
            p1.DataDodania = newOgloszenie.DataDodania;
        }
        public void Delete(int id)
        {
            Ogloszenie p1 = ogloszenia.SingleOrDefault(p => p.Id == id); //wyszukanie pierwszego elementu spełniającego kryteria
            if (p1 != null)
            {
                ogloszenia.Remove(p1);
            }
        }
    }
}
