using System.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjektTurnieju.Models
{
    public class Ogloszenie
    {
        [Key]
        public int Id { get; set; }
        public string Tytul { get; set; }

        public string Tresc { get; set; }

        public DateTime DataDodania { get; set; } = DateTime.Now;
   
    }
}
