﻿
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facade.Quantity;
using VL1.Pages.Quantity;
using VL1.Domain.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class EditModel : MeasuresPage
    {
        public EditModel(IMeasuresRepository r) : base(r) { }

        public async Task<IActionResult> OnGetAsync(string id) //otsib id
        {
            if (id == null) return NotFound();
            Item = MeasureViewFactory.Create(await db.Get(id));

            if (Item == null) return NotFound();
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await db.Update(MeasureViewFactory.Create(Item));

            return RedirectToPage("./Index");
        }
    }
}
