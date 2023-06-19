using System.ComponentModel.DataAnnotations;

namespace ProjektTurnieju.Models
{
	public class Druzyna
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string NazwaDruzyny { get; set; }
		[Required]
		public Uzytkownik KapitanDruzyny { get; set; } 
		public ICollection<Uzytkownik> Zawodnicy { get; set; }
	}
}
