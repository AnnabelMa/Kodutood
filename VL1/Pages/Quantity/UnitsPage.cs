using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Pages.Quantity
{
    public class UnitsPage : BasePage<IUnitsRepository, Unit, UnitView, UnitData>
    {
        protected internal UnitsPage(IUnitsRepository r, IMeasuresRepository m) : base(r)
        {
            PageTitle = "Units";
            Measures = CreateMeasures(m);
        }

        private static IEnumerable<SelectListItem> CreateMeasures(IMeasuresRepository r)
        {
            var list = new List<SelectListItem>();
            var measures = r.Get().GetAwaiter().GetResult();
            foreach (var m in measures)
            {
                list.Add(new SelectListItem(m.Data.Name, m.Data.Id));
            }
            return list;
        }

        public IEnumerable<SelectListItem> Measures { get; }

        public override string ItemId => Item.Id;

        protected internal override Unit ToObject(UnitView view)
        {
            return UnitViewFactory.Create(view);
        }

        protected internal override UnitView ToView(Unit obj)
        {
            return UnitViewFactory.Create(obj);
        }
    }
}
