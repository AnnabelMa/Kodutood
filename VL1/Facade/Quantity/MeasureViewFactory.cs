using System;
using System.Collections.Generic;
using System.Text;
using VL1.Domain.Quantity;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace Facade.Quantity
{
    //static klassis pole asjad päritavad!
    public static class MeasureViewFactory
    {
        public static Measure Create (MeasureView v) //v-view
        {
            var d = new MeasureData
            {
                Id = v.Id,
                Name = v.Name,
                Code = v.Code,
                Definition =v.Definition,
                ValidFrom = v.ValidFrom,
                ValidTo = v.ValidTo
            };
            return new Measure(d);
        }
        public static MeasureView Create(Measure o) //o-object
        {
            var v = new MeasureView
            {
                Id = o.Data.Id,
                Name = o.Data.Name,
                Code = o.Data.Code,
                Definition = o.Data.Definition,
                ValidFrom = o.Data.ValidFrom,
                ValidTo = o.Data.ValidTo
            };
            return v;
        }
    }
}
