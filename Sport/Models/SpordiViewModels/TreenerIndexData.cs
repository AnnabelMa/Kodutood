using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sport.Models.SpordiViewModels
{
    public class TreenerIndexData
    {
        public IEnumerable<Treener> Treenerid { get; set; }
        public IEnumerable<Spordiala> Spordialad { get; set; }
        public IEnumerable<Registreering> Registreeringud { get; set; }
    }
}
