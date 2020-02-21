
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Facade.Quantity;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class CreateModel : MeasuresPage
    {
        public CreateModel(IMeasuresRepository r) : base(r) { }

        public IActionResult OnGet() => Page();

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //kontrollib, kas mudel on õigesti tulnud; kas vastab etteantud nõuetele
            if (!ModelState.IsValid) return Page();
            await data.Add(MeasureViewFactory.Create(MeasureView));

            return RedirectToPage("./Index");
        }
    }
}
