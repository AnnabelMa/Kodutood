using VL1.Data.Quantity;
using VL1.Domain.Common;

namespace VL1.Domain.Quantity
{
    public sealed class Unit: Entity<UnitData>
    {
        public Unit(): this(null) { }
        public Unit(UnitData d): base(d) { }
    }
}
