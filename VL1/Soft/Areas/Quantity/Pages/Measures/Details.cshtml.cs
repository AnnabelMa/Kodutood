using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Facade.Quantity;
using Soft.Data;
using VL1.Pages.Quantity;
using VL1.Domain.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class DetailsModel : MeasuresPage
    {
        public DetailsModel(IMeasuresRepository r) : base(r){}

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null) return NotFound();
            
            Item =MeasureViewFactory.Create(await data.Get(id));

            if (Item == null) return NotFound();
            return Page();
        }
    }
}
