using VL1.Data.Common;
using VL1.Data.Quantity;
using VL1.Domain.Common;

namespace VL1.Domain.Quantity
{
    public class Measure : Entity<MeasureData>
    //ülesanne on vedada andmeid andmebaasi ja kasutajaliidese "kihi" vahel
    {
        public Measure() : this(null) { }
        //private MeasureData d;
        public Measure(MeasureData data) : base(data) { }

    }
}
