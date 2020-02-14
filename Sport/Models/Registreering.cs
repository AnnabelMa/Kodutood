using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Registreering
    {
        public int EnrollmentID { get; set; }
        public int SpordialaID { get; set; }
        public int SportlaseID { get; set; }
        public Spordiala Spordiala { get; set; }
        public Sportlane Sportlane { get; set; }
    }
}
