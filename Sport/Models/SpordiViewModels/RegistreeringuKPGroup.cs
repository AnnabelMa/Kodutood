using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sport.Models.SpordiViewModels
{
    public class RegistreeringuKPGroup
    {
        [DataType(DataType.Date)]
        public DateTime? RegistreeringuKP { get; set; }

        public int SportlaneCount { get; set; }
    }
}
