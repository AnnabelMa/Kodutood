using VL1.Aids;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
    public static  class UnitViewFactory
    {
        public static Unit Create(UnitView v) //v-view
        {
            var o = new Unit();
            Copy.Members(v, o.Data);
           
            return o;
        }
        public static UnitView Create(Unit o) //o-object
        {
            var v = new UnitView();
            Copy.Members(o.Data, v);
            
            return v;
        }
    }
}
