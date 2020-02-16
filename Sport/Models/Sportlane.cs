using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sport.Models
{
    public class Sportlane
    {
        public int ID { get; set; }
        public string Perekonnanimi { get; set; }
        public string Eesnimi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime RegistreeringuKP { get; set; }

        public ICollection<Registreering> Registreeringud { get; set; }
    }
}