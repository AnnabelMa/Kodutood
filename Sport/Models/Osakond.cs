using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Osakond
    {
        public int OsakondID { get; set; }

        [StringLength(50, MinimumLength =3)]
        public string Nimi { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Eelarve { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Algus KP")]
        public DateTime AlgusKP { get; set; }

        public int? TreenerID { get; set; }

        public Treener Administrator { get; set; }
        public ICollection<Spordiala> Spordialad { get; set; }
    }
}

