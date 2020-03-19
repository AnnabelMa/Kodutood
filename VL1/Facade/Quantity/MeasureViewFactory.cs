using VL1.Aids;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
    public static class MeasureViewFactory
    {
        public static Measure Create(MeasureView v) //v-view
        {
            var o = new Measure();
            Copy.Members(v, o.Data);
            
            return o;
        }
        public static MeasureView Create(Measure o) //o-object
        {
            var v = new MeasureView();
            Copy.Members(o.Data, v);
           
            return v;
        }
    }
}
