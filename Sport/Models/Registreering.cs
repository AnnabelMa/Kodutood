﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Registreering
    {
        public int RegistreeringID { get; set; }
        public int SpordialaID { get; set; }
        public int SportlaneID { get; set; }
       // [DisplayFormat(NullDisplayText = "No grade")] //KAS ON MINU NÄITEL VAJALIK?
       
        public Spordiala Spordiala { get; set; }
        public Sportlane Sportlane { get; set; }
    }
}
