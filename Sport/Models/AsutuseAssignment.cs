using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class AsutuseAssignment
    {
        [Key]
        public int TreenerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Asutuse lokatsioon")]
        public string Location { get; set; }

        public Treener Treener { get; set; }
    }
}
