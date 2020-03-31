using VL1.Data.Quantity;
using VL1.Domain.Common;

namespace VL1.Domain.Quantity
{
    public sealed class UnitFactor: Entity<UnitFactorData>
    {
        public UnitFactor() : this(null) { }
        public UnitFactor(UnitFactorData data) : base(data) { }

    }
}
