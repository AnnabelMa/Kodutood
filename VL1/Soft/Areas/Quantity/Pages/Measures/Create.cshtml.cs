using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.Measures
{
    public class CreateModel : MeasuresPage
    {
        public CreateModel(IMeasuresRepository r) : base(r) { }
        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await AddObject()) return Page();
            return RedirectToPage("./Index");
        }
    }
}
