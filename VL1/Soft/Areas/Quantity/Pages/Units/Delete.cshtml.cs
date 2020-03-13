using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.Units
{
    public class DeleteModel : UnitsPage
    {
        public DeleteModel(IUnitsRepository r, IMeasuresRepository m) : base(r, m) { }
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
