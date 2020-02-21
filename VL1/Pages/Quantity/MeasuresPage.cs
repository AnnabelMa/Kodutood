using VL1.Domain.Quantity;
using Facade.Quantity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace VL1.Pages.Quantity
{
    public abstract class MeasuresPage: PageModel
    {
        protected internal readonly IMeasuresRepository data;

        protected internal MeasuresPage(IMeasuresRepository r) => data = r;

        [BindProperty]
        public MeasureView Item { get; set; }
    }
}
