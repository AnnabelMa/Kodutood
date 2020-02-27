using System;
using System.Collections.Generic;
using System.Text;
using VL1.Data.Common;

namespace VL1.Data.Quantity
{
    public class UnitFactorData : PeriodData
    {
        public string UnitId { get; set; }
        public string SystemOfUnitsId { get; set; }
        public double Factor { get; set; }
    }
}
