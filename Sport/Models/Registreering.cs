using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sport.Models
{
    public enum Hinne
    {
        A, B, C, D, E, F
    }
    public class Registreering
    {
        public int EnrollmentID { get; set; }
        public int ÜksikalaID { get; set; }
        public int SportlaseID { get; set; }
        public Hinne? Hinne { get; set; }
        public Spordiala Spordiala { get; set; }
        public Sportlane Sportlane { get; set; }
    }
}
