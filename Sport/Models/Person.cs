using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public abstract class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string Perekonnanimi { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Eesnimi ei saa olla pikem kui 50 tähemärki!")]
        [Column("Eesnimi")]
        [Display(Name = "Eesnimi")]
        public string Eesnimi { get; set; }

        [Display(Name = "Täisnimi")]
        public string Täisnimi
        {
            get
            {
                return Perekonnanimi + ", " + Eesnimi;
            }
        }
    }
}
