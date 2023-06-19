using System.ComponentModel.DataAnnotations;

namespace ProjektTurnieju.Models
{
	public class Turniej
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Nazwa { get; set; }
		public ICollection<Druzyna> Druzyny{ get; set; }
	}
}
