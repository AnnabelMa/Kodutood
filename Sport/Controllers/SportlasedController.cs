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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date-desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var sportlased = from s in _context.Sportlased select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sportlased = sportlased.Where(s => s.Perekonnanimi.Contains(searchString) || s.Eesnimi.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    sportlased = sportlased.OrderByDescending(s => s.Perekonnanimi);
                    break;
                case "Date":
                    sportlased = sportlased.OrderBy(s => s.RegistreeringuKP);
                    break;
                case "date_desc":
                    sportlased = sportlased.OrderByDescending(s => s.RegistreeringuKP);
                    break;
                default:
                    sportlased = sportlased.OrderBy(s => s.Perekonnanimi);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Sportlane>.CreateAsync(sportlased.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Sportlased/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sportlane = await _context.Sportlased
                .Include(s => s.Registreeringud)
                .ThenInclude(e => e.Spordiala)
                .AsNoTracking()
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
        public async Task<IActionResult> Create(
            [Bind("RegistreeringuKP, Eesnimi, Perekonnanimi")] Sportlane sportlane)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(sportlane);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Ei saa muudatusi salvestada. " +
                    "Proovige uuesti! Kui midagi ei muutu, võtke ühendust süsteemi administraatoriga!.");            }
            return View(sportlane);
        }

        // GET: Sportlased/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportlane = await _context.Sportlased
                //include ja thenInclude meetodid aitavad laadida
                //Sportlane.Registreeringud nav property
                .Include(s => s.Registreeringud)
                .ThenInclude(e => e.Spordiala)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (sportlane == null)
            {
                return NotFound();
            }
            return View(sportlane);
        }

        // POST: Sportlased/Edit/5
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
            var sportlaneToUpdate = await _context.Sportlased.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Sportlane>(sportlaneToUpdate, "", 
                s => s.Eesnimi, s => s.Perekonnanimi, sportlaneToUpdate => sportlaneToUpdate.RegistreeringuKP))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Ei saa muudatusi salvestada. " +
                    "Proovige uuesti! Kui midagi ei muutu, võtke ühendust süsteemi administraatoriga!.");
                }
            }
            return View(sportlaneToUpdate);
        }
        // GET: Sportlased/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportlane = await _context.Sportlased
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sportlane == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Kustutamine ei õnnestunud."  +
                    "Proovige uuesti! Kui midagi ei muutu, võtke ühendust süsteemi administraatoriga!.";
            }
            return View(sportlane);
        }

        // POST: Sportlased/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportlane = await _context.Sportlased.FindAsync(id);
            if (sportlane == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Sportlased.Remove(sportlane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
           
        }

        private bool SportlaneExists(int id)
        {
            return _context.Sportlased.Any(e => e.ID == id);
        }
    }
}
