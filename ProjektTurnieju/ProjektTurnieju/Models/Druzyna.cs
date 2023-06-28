using System.ComponentModel.DataAnnotations;

namespace ProjektTurnieju.Models
{
	public class Druzyna
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string NazwaDruzyny { get; set; }
		[Required]
		public int IdKapitanaDruzyny { get; set; } 
		public ICollection<Uzytkownik> Zawodnicy { get; set; }
	}
}
