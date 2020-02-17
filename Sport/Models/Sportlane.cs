using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Sportlane : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "RegistreeringuKP")]
        public DateTime RegistreeringuKP { get; set; }

        public ICollection<Registreering> Registreeringud { get; set; }
    }
}