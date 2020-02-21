using System.Collections.Generic;
using System.Threading.Tasks;
using Facade.Quantity;
using VL1.Pages.Quantity;
using VL1.Domain.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : MeasuresPage
    {
        public IndexModel(IMeasuresRepository r) : base(r) { }

        public async Task OnGetAsync()
        {
            var l = await data.Get();
            var Items = new List<MeasureView>();

            foreach (var e in l) { Items.Add(MeasureViewFactory.Create(e));}
        }
    }
}
