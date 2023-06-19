using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace ProjektTurnieju.Models
{
    public class Uzytkownik
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Haslo { get; set; }
        [Required]
        public Role Rola { get; set; }   
		[Required]
		public string Imie { get; set; }
		[Required]
		public string Nazwisko { get; set; }
		[Required]
		public string Nick { get; set; }
		public bool CzyMaDruzyne { get; set; }
	}
}
