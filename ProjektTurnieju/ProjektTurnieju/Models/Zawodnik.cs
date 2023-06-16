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

	}
}
