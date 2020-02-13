using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public class Sportlane
    {
        public int ID { get; set; }
        public string Perekonnanimi { get; set; }
        public string Eesnimi { get; set; }
        public DateTime RegistreeringuKP { get; set; }

        public ICollection<Registreering> Registreeringud { get; set; }
    }
}