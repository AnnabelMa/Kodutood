using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Treener
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Perekonnanimi")]
        [StringLength(50)]
        public string Perekonnanimi { get; set; }

        [Required]
        [Column("Eesnimi")]
        [Display(Name = "Eesnimi")]
        [StringLength(50)]
        public string Eesnimi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Palkamise KP")]
        public DateTime PalkamiseKP { get; set; }

        [Display(Name = "Täisnimi")]
        public string Täisnimi
        {
            get { return Perekonnanimi + ", " + Eesnimi; }
        }

        public ICollection<SpordialaAssignment> SpordialaAssignments { get; set; }
        public AsutuseAssignment AsutuseAssignment { get; set; }
    }
}
