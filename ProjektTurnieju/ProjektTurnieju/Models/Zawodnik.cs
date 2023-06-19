using System.ComponentModel.DataAnnotations;

namespace ProjektTurnieju.Models
{
	public class Zawodnik : Uzytkownik
	{
        [Key]
		public int Id { get; set; }
        [Required]
		public string Imie { get; set; }
        [Required]
		public string Nazwisko{ get; set; }
        [Required]
		public string Nick { get; set; }
        [Required]
		public bool CzyMaDruzyne { get; set; }
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
                CzyMaDruzyne = false
            };
            Zawodnik z2 = new Zawodnik
            {
                Id = 2,
                Imie = "Dawid",
                Nazwisko = "Tajny",
                Nick = "Jolo",
                CzyMaDruzyne = false
            };
            Zawodnik z3 = new Zawodnik
            {
                Id = 3,
                Imie = "Bartosz",
                Nazwisko = "Stankiewicz",
                Nick = "klekot",
                CzyMaDruzyne = false
            };
            return new List<Zawodnik> { z1, z2, z3 };
        }
    }
}
