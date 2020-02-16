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
    public class SpordialasController : Controller
    {
        private readonly SpordiContext _context;

        public SpordialasController(SpordiContext context)
        {
            _context = context;
        }

        // GET: Spordialas
        public async Task<IActionResult> Index()
        {
            var spordialad = _context.Spordiala //VÕI SpordialaD/S ???
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

            var spordiala = await _context.Spordiala
                .Include(s => s.Osakond)
                .FirstOrDefaultAsync(m => m.SpordialaID == id);
            if (spordiala == null)
            {
                return NotFound();
            }

            return View(spordiala);
        }

        // GET: Spordialas/Create
        public IActionResult Create()
        {
            ViewData["OsakondID"] = new SelectList(_context.Osakonds, "OsakondID", "OsakondID");
            return View();
        }

        // POST: Spordialas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpordialaID,Nimi,Tulemused,OsakondID")] Spordiala spordiala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spordiala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OsakondID"] = new SelectList(_context.Osakonds, "OsakondID", "OsakondID", spordiala.OsakondID);
            return View(spordiala);
        }

        // GET: Spordialas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spordiala = await _context.Spordiala.FindAsync(id);
            if (spordiala == null)
            {
                return NotFound();
            }
            ViewData["OsakondID"] = new SelectList(_context.Osakonds, "OsakondID", "OsakondID", spordiala.OsakondID);
            return View(spordiala);
        }

        // POST: Spordialas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpordialaID,Nimi,Tulemused,OsakondID")] Spordiala spordiala)
        {
            if (id != spordiala.SpordialaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spordiala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpordialaExists(spordiala.SpordialaID))
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
            ViewData["OsakondID"] = new SelectList(_context.Osakonds, "OsakondID", "OsakondID", spordiala.OsakondID);
            return View(spordiala);
        }

        // GET: Spordialas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spordiala = await _context.Spordiala
                .Include(s => s.Osakond)
                .FirstOrDefaultAsync(m => m.SpordialaID == id);
            if (spordiala == null)
            {
                return NotFound();
            }

            return View(spordiala);
        }

        // POST: Spordialas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spordiala = await _context.Spordiala.FindAsync(id);
            _context.Spordiala.Remove(spordiala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpordialaExists(int id)
        {
            return _context.Spordiala.Any(e => e.SpordialaID == id);
        }
    }
}
