using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Treener : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "PalkamiseKP")]
        public DateTime PalkamiseKP { get; set; }

        public ICollection<SpordialaAssignment> SpordialaAssignments { get; set; }
        public AsutuseAssignment AsutuseAssignment { get; set; }
    }
}
