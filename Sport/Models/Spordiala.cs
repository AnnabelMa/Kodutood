using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sport.Models
{
    public class Spordiala
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpordialaID { get; set; }
        public string Nimi { get; set; }
        public int Tulemused { get; set; }

        public ICollection<Registreering> Registreeringud { get; set; }
    }
}
