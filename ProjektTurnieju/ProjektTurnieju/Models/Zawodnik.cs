namespace ProjektTurnieju.Models
{
	public class Zawodnik : Uzytkownik
	{
		public int Id { get; set; }
		public string Imie { get; set; }
		public string Nazwisko{ get; set; }
		public string Nick { get; set; }
		public bool CzyMaDruzyne { get; set; }
		public bool CzyUsuniety { get; set; }
        public static List<Zawodnik> GetZawodnicy()
        {
            Zawodnik z1 = new Zawodnik
            {
                Login = "janusz",
                Haslo = "janusz123", 
                Id = 1,
                Imie = "Janusz",
                Nazwisko = "Kowalski",
                Nick = "JanekKijanek",
                CzyMaDruzyne = false,
                CzyUsuniety = false
            };
            Zawodnik z2 = new Zawodnik
            {
                Id = 2,
                Imie = "Dawid",
                Nazwisko = "Tajny",
                Nick = "Jolo",
                CzyMaDruzyne = false,
                CzyUsuniety = false
            };
            Zawodnik z3 = new Zawodnik
            {
                Id = 3,
                Imie = "Bartosz",
                Nazwisko = "Stankiewicz",
                Nick = "klekot",
                CzyMaDruzyne = false,
                CzyUsuniety = false
            };
            return new List<Zawodnik> { z1, z2, z3 };
        }
    }
}
