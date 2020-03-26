using System;
using System.Collections.Generic;
using System.Text;
using VL1.Data.Common;

namespace VL1.Data.Quantity
{
    public class CommonTerm : PeriodData
    {
        public string MasterId { get; set; }
        public string TermId { get; set; }
        public int Power { get; set; }//aste, mis näitab ühiku sõltuvust
    }
}
