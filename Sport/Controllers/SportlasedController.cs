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
    public class SportlasedController : Controller
    {
        private readonly SpordiContext _context;

        public SportlasedController(SpordiContext context)
        {
            _context = context;
        }

        // GET: Sportlased
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sportlased.ToListAsync());
        }

        // GET: Sportlased/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportlane = await _context.Sportlased
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sportlane == null)
            {
                return NotFound();
            }

            return View(sportlane);
        }

        // GET: Sportlased/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sportlased/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Perekonnanimi,Eesnimi,RegistreeringuKP")] Sportlane sportlane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportlane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportlane);
        }

        // GET: Sportlased/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportlane = await _context.Sportlased.FindAsync(id);
            if (sportlane == null)
            {
                return NotFound();
            }
            return View(sportlane);
        }

        // POST: Sportlased/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Perekonnanimi,Eesnimi,RegistreeringuKP")] Sportlane sportlane)
        {
            if (id != sportlane.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportlane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportlaneExists(sportlane.ID))
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
            return View(sportlane);
        }

        // GET: Sportlased/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportlane = await _context.Sportlased
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sportlane == null)
            {
                return NotFound();
            }

            return View(sportlane);
        }

        // POST: Sportlased/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportlane = await _context.Sportlased.FindAsync(id);
            _context.Sportlased.Remove(sportlane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportlaneExists(int id)
        {
            return _context.Sportlased.Any(e => e.ID == id);
        }
    }
}
