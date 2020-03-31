using VL1.Data.Quantity;
using VL1.Domain.Common;

namespace VL1.Domain.Quantity
{
    public sealed class SystemOfUnits: Entity<SystemOfUnitsData>
    {
        public SystemOfUnits() : this(null) { }
        public SystemOfUnits(SystemOfUnitsData data) : base(data) { }
    }
}
