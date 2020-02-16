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
        public async Task<IActionResult> Index(int? id, int? spordialaID)
        {
            var viewModel = new TreenerIndexData();
            viewModel.Treenerid = await _context.Treenerid
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
                Treener treener = viewModel.Treenerid.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Spordialad = treener.SpordialaAssignments.Select(s => s.Spordiala);
            }

            if (spordialaID != null)
            {
                ViewData["SpordialaID"] = spordialaID.Value;
                var selectedCourse = viewModel.Spordialad.Where(x => x.SpordialaID == spordialaID).Single();
                await _context.Entry(selectedCourse).Collection(x => x.Registreeringud).LoadAsync();
                foreach (Registreering registreering in selectedCourse.Registreeringud)
                {
                    await _context.Entry(registreering).Reference(x => x.Sportlane).LoadAsync();
                }
                viewModel.Registreerings = selectedCourse.Registreeringud;
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

            var treener = await _context.Treenerid
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

            var treener = await _context.Treenerid
                .Include(i => i.AsutuseAssignment)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (treener == null)
            {
                return NotFound();
            }
            return View(treener);
        }

        // POST: Treenerid/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var treenerToUpdate = await _context.Treenerid
        .Include(i => i.AsutuseAssignment)
        .FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Treener>(
                treenerToUpdate,
                "",
                i => i.Eesnimi, i => i.Perekonnanimi, i => i.PalkamiseKP, i => i.AsutuseAssignment))
            {
                if (String.IsNullOrWhiteSpace(treenerToUpdate.AsutuseAssignment?.Location))
                {
                    treenerToUpdate.AsutuseAssignment = null;
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(treenerToUpdate);
        }

        // GET: Treenerid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treener = await _context.Treenerid
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
            var treener = await _context.Treenerid.FindAsync(id);
            _context.Treenerid.Remove(treener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreenerExists(int id)
        {
            return _context.Treenerid.Any(e => e.ID == id);
        }
    }
}
