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

namespace Sport.Controllers
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
                viewModel.Registreeringud = selectedCourse.Registreeringud;
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
            var treener = new Treener();
            treener.SpordialaAssignments = new List<SpordialaAssignment>();
            PopulateAssignedSpordialaData(treener);
            return View();
        }

        // POST: Treenerid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Eesnimi, PalkamiseKP, Perekonnanimi, AsutuseAssignment")] Treener treener, string[] selectedSpordialad)
        {
            if (selectedSpordialad != null)
            {
                treener.SpordialaAssignments = new List<SpordialaAssignment>();
                foreach (var spordiala in selectedSpordialad)
                {
                    var spordialaToAdd = new SpordialaAssignment { TreenerID = treener.ID, SpordialaID = int.Parse(spordiala) };
                    treener.SpordialaAssignments.Add(spordialaToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(treener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                PopulateAssignedSpordialaData(treener);
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
                .Include(i => i.SpordialaAssignments)
                .ThenInclude(i => i.Spordiala)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (treener == null)
            {
                return NotFound();
            }
            PopulateAssignedSpordialaData(treener);
            return View(treener);
        }
        private void PopulateAssignedSpordialaData(Treener treener)
        {
            var allSpordialad = _context.Spordialad;
            var treenerSpordialad = new HashSet<int>(treener.SpordialaAssignments.Select(c => c.SpordialaID));
            var viewModel = new List<AssignedSpordialaData>();
            foreach (var spordiala in allSpordialad)
            {
                viewModel.Add(new AssignedSpordialaData
                {
                    SpordialaID = spordiala.SpordialaID,
                    Nimi = spordiala.Nimi,
                    Assigned = treenerSpordialad.Contains(spordiala.SpordialaID)
                });
            }
            ViewData["Courses"] = viewModel;
        }

        // POST: Treenerid/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedSpordialad)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var treenerToUpdate = await _context.Treenerid
                .Include(i => i.AsutuseAssignment)
                .Include (i => i.SpordialaAssignments)
                .ThenInclude(i => i.Spordiala)
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
                UpdateTreenerSpordialad(selectedSpordialad, treenerToUpdate);
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
            UpdateTreenerSpordialad(selectedSpordialad, treenerToUpdate);
            PopulateAssignedSpordialaData(treenerToUpdate);
            return View(treenerToUpdate);
        }
        private void UpdateTreenerSpordialad(string[] selectedSpordiala, Treener treenerToUpdate)
        {
            if (selectedSpordiala == null)
            {
                treenerToUpdate.SpordialaAssignments = new List<SpordialaAssignment>();
                return;
            }

            var selectedSpordialaHS = new HashSet<string>(selectedSpordiala);
            var treenerSpordiala = new HashSet<int>
                (treenerToUpdate.SpordialaAssignments.Select(c => c.Spordiala.SpordialaID));
            foreach (var spordiala in _context.Spordialad)
            {
                if (selectedSpordialaHS.Contains(spordiala.SpordialaID.ToString()))
                {
                    if (!treenerSpordiala.Contains(spordiala.SpordialaID))
                    {
                        treenerToUpdate.SpordialaAssignments.Add(new SpordialaAssignment { TreenerID = treenerToUpdate.ID, SpordialaID = spordiala.SpordialaID });
                    }
                }
                else
                {

                    if (treenerSpordiala.Contains(spordiala.SpordialaID))
                    {
                        SpordialaAssignment spordialaToRemove = treenerToUpdate.SpordialaAssignments.FirstOrDefault(i => i.SpordialaID == spordiala.SpordialaID);
                        _context.Remove(spordialaToRemove);
                    }
                }
            }
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
            Treener treener = await _context.Treenerid
                .Include(i => i.SpordialaAssignments)
                .SingleAsync(i => i.ID == id);

            var osakonnad = await _context.Osakonnad
                .Where(d => d.TreenerID == id)
                .ToListAsync();
            osakonnad.ForEach(d => d.TreenerID = null);

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
