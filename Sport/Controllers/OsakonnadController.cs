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
                .AsNoTracking()
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

            var osakond = await _context.Osakonnad
                .Include(i => i.Administrator)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OsakondID == id);

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
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var osakondToUpdate = await _context.Osakonnad.Include(i => i.Administrator).FirstOrDefaultAsync(m => m.OsakondID == id);

            if (osakondToUpdate == null)
            {
                Osakond deletedOsakond = new Osakond();
                await TryUpdateModelAsync(deletedOsakond);
                ModelState.AddModelError(string.Empty, "Ei saa muudatusi salvestada. Osakond on teise kasutaja poolt kustutatud.");
                ViewData["TreenerID"] = new SelectList(_context.Treenerid, "ID", "Täisnimi", deletedOsakond.TreenerID);
                return View(deletedOsakond);
            }
            _context.Entry(osakondToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Osakond>(osakondToUpdate, "", 
                s=> s.Nimi, s => s.AlgusKP, s => s.Eelarve, s => s.TreenerID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Osakond)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                           "Ei saa muudatusi salvestada. Osakond on teise kasutaja poolt kustutatud.");
                    }
                    else
                    {
                        var databaseValues = (Osakond)databaseEntry.ToObject();

                        if (databaseValues.Nimi != clientValues.Nimi)
                        {
                            ModelState.AddModelError("Nimi", $"Current value: {databaseValues.Nimi}");
                        }
                        if (databaseValues.Eelarve != clientValues.Eelarve)
                        {
                            ModelState.AddModelError("Eelarve", $"Current value: {databaseValues.Eelarve:c}");
                        }
                        if (databaseValues.AlgusKP != clientValues.AlgusKP)
                        {
                            ModelState.AddModelError("AlgusKP", $"Current value: {databaseValues.AlgusKP:d}");
                        }
                        if (databaseValues.TreenerID != clientValues.TreenerID)
                        {
                            Treener databaseInstructor = await _context.Treenerid.FirstOrDefaultAsync(i => i.ID == databaseValues.TreenerID);
                            ModelState.AddModelError("TreenerID", $"Current value: {databaseInstructor?.Täisnimi}");
                        }

                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you got the original value. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to edit this record, click "
                                + "the Save button again. Otherwise click the Back to List hyperlink.");
                        osakondToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            ViewData["TreenerID"] = new SelectList(_context.Treenerid, "ID", "Täisnimi", osakondToUpdate.TreenerID);
            return View(osakondToUpdate);
        }
    

        // GET: Osakonnad/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osakond = await _context.Osakonnad
                .Include(o => o.Administrator)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OsakondID == id);
            if (osakond == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "The record you attempted to delete "
                    + "was modified by another user after you got the original values. "
                    + "The delete operation was canceled and the current values in the "
                    + "database have been displayed. If you still want to delete this "
                    + "record, click the Delete button again. Otherwise "
                    + "click the Back to List hyperlink.";
            }
            return View(osakond);
        }

        // POST: Osakonnad/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Osakond osakond)
        {
            try
            {
                if (await _context.Osakonnad.AnyAsync(m => m.OsakondID == osakond.OsakondID))
                {
                    _context.Osakonnad.Remove(osakond);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = osakond.OsakondID });
            }
        }

        private bool OsakondExists(int id)
        {
            return _context.Osakonnad.Any(e => e.OsakondID == id);
        }
    }
}
