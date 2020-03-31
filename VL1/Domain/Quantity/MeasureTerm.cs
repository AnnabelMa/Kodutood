using VL1.Data.Quantity;
using VL1.Domain.Common;

namespace VL1.Domain.Quantity
{
    public sealed class MeasureTerm : Entity<MeasureTermData>
    {
        public MeasureTerm() : this(null) { }
        public MeasureTerm(MeasureTermData data) : base(data) { }
    }
}
