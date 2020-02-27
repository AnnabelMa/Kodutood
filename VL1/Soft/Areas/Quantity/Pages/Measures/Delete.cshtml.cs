using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Facade.Quantity;
using Soft.Data;

namespace VL1.Soft
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MeasureView MeasureView { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeasureView = await _context.MeasureView.FirstOrDefaultAsync(m => m.Id == id);

            if (MeasureView == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeasureView = await _context.MeasureView.FindAsync(id);

            if (MeasureView != null)
            {
                _context.MeasureView.Remove(MeasureView);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
