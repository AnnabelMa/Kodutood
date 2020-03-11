using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Pages.Quantity
{
    public class MeasuresPage: BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>
    {
        protected internal MeasuresPage(IMeasuresRepository r): base(r)
        {
            PageTitle = "Measures";
        }
        public override string ItemId => Item.Id;
        protected internal override Measure ToObject(MeasureView view)
        {
            return MeasureViewFactory.Create(view);
        }

        protected internal override MeasureView ToView(Measure obj)
        {
            return MeasureViewFactory.Create(obj);
        }
    }
}
