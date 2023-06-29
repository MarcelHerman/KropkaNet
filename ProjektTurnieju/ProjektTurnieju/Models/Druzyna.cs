using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ProjektTurnieju.Models
{
	public class Druzyna
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string NazwaDruzyny { get; set; }
		[Required]
		public int IdKapitanaDruzyny { get; set; } 
		public List<Uzytkownik> ?Zawodnicy { get; set; }
	}
}
