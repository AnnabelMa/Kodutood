using System.Threading.Tasks;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : MeasuresPage
    {
        public IndexModel(IMeasuresRepository r) : base(r) { }

        public async Task OnGetAsync(string sortOrder, string currentFilter, 
            string searchString, int? pageIndex)
        {
            await GetList( sortOrder,  currentFilter, searchString, pageIndex);
        }
    }
}
