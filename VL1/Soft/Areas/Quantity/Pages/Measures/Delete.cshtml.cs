using System.Threading.Tasks;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;
using VL1.Facade.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.Measures
{
    public class DeleteModel : MeasuresPage
    {
        public DeleteModel(IMeasuresRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            await GetObject(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            await DeleteObject(id);
            return RedirectToPage("./Index");
        }
    }
}
