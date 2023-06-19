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
        Role Rola { get; set; }   
        public string IdRoli { get; set; }
    }
}
