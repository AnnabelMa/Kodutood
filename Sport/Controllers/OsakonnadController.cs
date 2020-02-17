using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sport.Data;
using Sport.Models;

namespace Sport.Controllers
{
    public class OsakonnadController : Controller
    {
        private readonly SpordiContext _context;

        public OsakonnadController(SpordiContext context)
        {
            _context = context;
        }

        // GET: Osakonnad
        public async Task<IActionResult> Index()
        {
            var spordiContext = _context.Osakonnad.Include(o => o.Administrator);
            return View(await spordiContext.ToListAsync());
        }

        // GET: Osakonnad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osakond = await _context.Osakonnad
                .Include(o => o.Administrator)
                .FirstOrDefaultAsync(m => m.OsakondID == id);
            if (osakond == null)
            {
                return NotFound();
            }

            return View(osakond);
        }

        // GET: Osakonnad/Create
        public IActionResult Create()
        {
            ViewData["TreenerID"] = new SelectList(_context.Treenerid, "ID", "Täisnimi");
            return View();
        }

        // POST: Osakonnad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OsakondID,Nimi,Eelarve,AlgusKP,TreenerID,RowVersion")] Osakond osakond)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osakond);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TreenerID"] = new SelectList(_context.Treenerid, "ID", "Täisnimi", osakond.TreenerID);
            return View(osakond);
        }

        // GET: Osakonnad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osakond = await _context.Osakonnad.FindAsync(id);
            if (osakond == null)
            {
                return NotFound();
            }
            ViewData["TreenerID"] = new SelectList(_context.Treenerid, "ID", "Täisnimi", osakond.TreenerID);
            return View(osakond);
        }

        // POST: Osakonnad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OsakondID,Nimi,Eelarve,AlgusKP,TreenerID,RowVersion")] Osakond osakond)
        {
            if (id != osakond.OsakondID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osakond);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsakondExists(osakond.OsakondID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TreenerID"] = new SelectList(_context.Treenerid, "ID", "Täisnimi", osakond.TreenerID);
            return View(osakond);
        }

        // GET: Osakonnad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osakond = await _context.Osakonnad
                .Include(o => o.Administrator)
                .FirstOrDefaultAsync(m => m.OsakondID == id);
            if (osakond == null)
            {
                return NotFound();
            }

            return View(osakond);
        }

        // POST: Osakonnad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osakond = await _context.Osakonnad.FindAsync(id);
            _context.Osakonnad.Remove(osakond);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsakondExists(int id)
        {
            return _context.Osakonnad.Any(e => e.OsakondID == id);
        }
    }
}
