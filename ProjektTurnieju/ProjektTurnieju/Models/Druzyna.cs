namespace ProjektTurnieju.Models
{
	public class Druzyna
	{
		public string NazwaDruzyny { get; set; }
		public Kapitan KapitanDruzyny { get; set; } 
		public Zawodnik[] Zawodnicy { get; set; }
	}
}
