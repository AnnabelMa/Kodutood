using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.Measures
{
    public class EditModel : MeasuresPage
    {
        public EditModel(IMeasuresRepository r) : base(r) { }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            await GetObject(id);
            return Page();
        }
       
        public async Task<IActionResult> OnPostAsync()
        {
            await UpdateObject();
            return RedirectToPage("./Index");
        }
    }
}
