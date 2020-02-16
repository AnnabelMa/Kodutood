using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sport.Data;
using Sport.Models;
using Sport.Models.SpordiViewModels;

namespace Sport.Views
{
    public class TreeneridController : Controller
    {
        private readonly SpordiContext _context;

        public TreeneridController(SpordiContext context)
        {
            _context = context;
        }

        // GET: Treenerid
        public async Task<IActionResult> Index(int? id, int? SpordialaID)
        {
            var viewModel = new TreenerIndexData();
            viewModel.Treeners = await _context.Treeners
                  .Include(i => i.AsutuseAssignment)
                  .Include(i => i.SpordialaAssignments)
                    .ThenInclude(i => i.Spordiala)
                        .ThenInclude(i => i.Registreeringud)
                            .ThenInclude(i => i.Sportlane)
                  .Include(i => i.SpordialaAssignments)
                    .ThenInclude(i => i.Spordiala)
                        .ThenInclude(i => i.Osakond)
                  .AsNoTracking()
                  .OrderBy(i => i.Perekonnanimi)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["TreenerID"] = id.Value;
                Treener treener = viewModel.Treeners.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Spordialas = treener.SpordialaAssignments.Select(s => s.Spordiala);
            }

            if (SpordialaID != null)
            {
                ViewData["SpordialaID"] = SpordialaID.Value;
                viewModel.Registreerings = viewModel.Spordialas.Where(
                    x => x.SpordialaID == SpordialaID).Single().Registreeringud;
            }

            return View(viewModel);
        }

        // GET: Treenerid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treener = await _context.Treeners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (treener == null)
            {
                return NotFound();
            }

            return View(treener);
        }

        // GET: Treenerid/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treenerid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Perekonnanimi,Eesnimi,PalkamiseKP")] Treener treener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treener);
        }

        // GET: Treenerid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treener = await _context.Treeners.FindAsync(id);
            if (treener == null)
            {
                return NotFound();
            }
            return View(treener);
        }

        // POST: Treenerid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Perekonnanimi,Eesnimi,PalkamiseKP")] Treener treener)
        {
            if (id != treener.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreenerExists(treener.ID))
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
            return View(treener);
        }

        // GET: Treenerid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treener = await _context.Treeners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (treener == null)
            {
                return NotFound();
            }

            return View(treener);
        }

        // POST: Treenerid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treener = await _context.Treeners.FindAsync(id);
            _context.Treeners.Remove(treener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreenerExists(int id)
        {
            return _context.Treeners.Any(e => e.ID == id);
        }
    }
}
