using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sport.Models
{
    public class Registreering
    {
        public int RegistreeringID { get; set; }
        public int SpordialaID { get; set; }
        public int SportlaseID { get; set; }
        public Spordiala Spordiala { get; set; }
        public Sportlane Sportlane { get; set; }
    }
}
