using VL1.Data.Quantity;
using VL1.Domain.Common;

namespace VL1.Domain.Quantity
{
    public sealed class UnitTerm: Entity<UnitTermData>
    {
        public UnitTerm() : this(null) { }
        public UnitTerm(UnitTermData data) : base(data) { }
    }
}
