using System.Threading.Tasks;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;
using Facade.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.Measures
{
    public class DeleteModel : MeasuresPage
    {
        public DeleteModel(IMeasuresRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null) return NotFound();

            Item = MeasureViewFactory.Create(await db.Get(id));

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null) return NotFound();

            await db.Delete(id);

            return RedirectToPage("./Index");
        }

    }
}
