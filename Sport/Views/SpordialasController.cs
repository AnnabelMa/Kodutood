using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sport.Data;
using Sport.Models;

namespace Sport.Views
{
    public class SpordialadController : Controller
    {
        private readonly SpordiContext _context;

        public SpordialadController(SpordiContext context)
        {
            _context = context;
        }

        // GET: Spordialad
        public async Task<IActionResult> Index()
        {
            var spordialad = _context.Spordialad
                .Include(c => c.Osakond)
                .AsNoTracking();
            return View(await spordialad.ToListAsync());
        }

        // GET: Spordialas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spordiala = await _context.Spordialad
                .Include(s => s.Osakond)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SpordialaID == id);
            if (spordiala == null)
            {
                return NotFound();
            }

            return View(spordiala);
        }

        // GET: Spordialad/Create
        public IActionResult Create()
        {
            PopulateOsakonnadDropDownList();
            return View();
        }

        // POST: Spordialad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpordialaID,OsakonnaID,Nimi")] Spordiala spordiala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spordiala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateOsakonnadDropDownList(spordiala.OsakondID);
            return View(spordiala);
        }

        // GET: Spordialas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spordiala = await _context.Spordialad
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SpordialaID == id);
            if (spordiala == null)
            {
                return NotFound();
            }
            PopulateOsakonnadDropDownList(spordiala.OsakondID);
            return View(spordiala);
        }

        // POST: Spordialas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Spordialad
                .FirstOrDefaultAsync(c => c.SpordialaID == id);

            if (await TryUpdateModelAsync<Spordiala>(courseToUpdate,
                "",
                c => c.SpordialaID, c => c.Nimi))
            {
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
            PopulateOsakonnadDropDownList(courseToUpdate.OsakondID);
            return View(courseToUpdate);
        }
        private void PopulateOsakonnadDropDownList(object selectedOsakond = null)
        {
            var OsakonnadsQuery = from d in _context.Osakonnad
                                   orderby d.Nimi
                                   select d;
            ViewBag.OsakondID = new SelectList(OsakonnadsQuery.AsNoTracking(), "OsakondID", "Nimi", selectedOsakond);
        }

        // GET: Spordialad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spordiala = await _context.Spordialad
                .Include(s => s.Osakond)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SpordialaID == id);
            if (spordiala == null)
            {
                return NotFound();
            }

            return View(spordiala);
        }

        // POST: Spordialad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spordiala = await _context.Spordialad.FindAsync(id);
            _context.Spordialad.Remove(spordiala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpordialaExists(int id)
        {
            return _context.Spordialad.Any(e => e.SpordialaID == id);
        }
    }
}
