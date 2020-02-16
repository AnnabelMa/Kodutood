using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class SpordialaAssignment
    {
        public int TreenerID { get; set; }
        public int SpordialaID { get; set; }
        public Treener Treener { get; set; }

        public Spordiala Spordiala { get; set; }
    }
}
