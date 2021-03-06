﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Sportlane : Person
    {
        // Kood,  inheritance Person jaoks:

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registreeringu kuupäev")]
        public DateTime RegistreeringuKP { get; set; }

        public ICollection<Registreering> Registreeringud { get; set; }

    }

        //Kood enne Person.cs loomist:
        /*public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string Perekonnanimi { get; set; }
        [StringLength(50)]
        [Column("Eesnimi")]
        [Display(Name = "Eesnimi")]
        public string Eesnimi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        [Display(Name = "RegistreeringuKP")]
        public DateTime RegistreeringuKP { get; set; }
        [Display(Name = "Täisnimi")]
        public string Täisnimi
        {
            get
            {
                return Perekonnanimi + ", " + Eesnimi;
            }
        }
        public ICollection<Registreering> Registreeringud { get; set; }

        */
    
}