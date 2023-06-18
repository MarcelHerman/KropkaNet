using System.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjektTurnieju.Models
{
    public class Ogloszenie
    {
        public int Id { get; set; }
        public string Tytul { get; set; }

        public string Tresc { get; set; }

        public DateTime DataDodania { get; set; } = DateTime.Now;
        public static List<Ogloszenie> GetOgloszenia()
        {
            Ogloszenie o1 = new Ogloszenie
            {
                Id = 1,
                Tytul = "Koniec turnieju CSGO!",
                Tresc = "Dziękujemy za udział! Wygrywa drużyna Szprotki!",
                DataDodania = DateTime.ParseExact("2023-06-20 12:51:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            Ogloszenie o2 = new Ogloszenie
            {
                Id = 2,
                Tytul = "Rozpoczynamy zawody z League of Legends!",
                Tresc = "Pierwszy mecz to Gryzaki kontra Byki, który odbędzie się jutro o godzinie 12:00! Zapraszamy!",
                DataDodania = DateTime.ParseExact("2023-06-18 17:37:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            Ogloszenie o3 = new Ogloszenie
            {
                Id = 3,
                Tytul = "Zawody z Fortnite trwają!",
                Tresc = "Kolejny mecz już dzisiaj o godzinie 20:00! Grają drużyny FrancuskieBagiety i CzokoKrem! Zapraszamy!",
                DataDodania = DateTime.ParseExact("2023-06-16 13:12:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
            return new List<Ogloszenie> { o1, o2, o3 };
        }
    }
}
