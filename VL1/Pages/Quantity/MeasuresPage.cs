using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Pages.Quantity
{
    public abstract class MeasuresPage: BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>
    {
        protected internal MeasuresPage(IMeasuresRepository r=null): base(r)
        {
            PageTitle = "Measures";
        }
        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string getPageUrl() => "/Quantity/Measures";

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
