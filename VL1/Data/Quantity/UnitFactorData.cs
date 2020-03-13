using VL1.Data.Common;

namespace VL1.Data.Quantity
{
    public sealed class UnitFactorData : PeriodData
    {
        public string UnitId { get; set; }
        public string SystemOfUnitsId { get; set; }
        public double Factor { get; set; }
    }
}
 