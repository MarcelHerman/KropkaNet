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
		public Zawodnik KapitanDruzyny { get; set; } 
		public ICollection<Zawodnik> Zawodnicy { get; set; }
	}
}
