using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Spordiala
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Number")]
        public int SpordialaID { get; set; }

        [StringLength(50, MinimumLength =3)]
        public string Nimi { get; set; }

        [Range(0,5)]
        public int Tulemused { get; set; }

        public int OsakondID { get; set; }

        public Osakond Osakond { get; set; }

        public ICollection<Registreering> Registreeringud { get; set; }
        public ICollection<SpordialaAssignment> SpordialaAssignments { get; set; }
    }
}
