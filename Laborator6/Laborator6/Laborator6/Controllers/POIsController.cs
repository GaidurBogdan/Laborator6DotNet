using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;

namespace Presentation.Controllers
{
    public class POIsController : Controller
    {
        private readonly POIContext _context;

        public POIsController(POIContext context)
        {
            _context = context;
        }

        // GET: POIs
        public async Task<IActionResult> Index() => View(await _context.POIs.ToListAsync());

        // GET: POIs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var POI = await _context.POIs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (POI == null)
            {
                return NotFound();
            }

            return View(POI);
        }

        // GET: POIs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: POIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string description, string name)
        {
            POI poi = new POI(description, name);

            if (ModelState.IsValid)
            {
                _context.Add(poi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poi);
        }

        // GET: POIs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poi = await _context.POIs.FindAsync(id);
            if (poi == null)
            {
                return NotFound();
            }
            return View(poi);
        }

        // POST: POIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, string name, string description)
        {
            var poi = await _context.POIs.FindAsync(id);

            poi.SetName(name);
            poi.SetDescription(description);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POIsExists(id))
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
            return View(poi);
        }

        // GET: POIs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poi = await _context.POIs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poi == null)
            {
                return NotFound();
            }

            return View(poi);
        }

        // POST: POIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var poi = await _context.POIs.FindAsync(id);
            _context.POIs.Remove(poi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POIsExists(Guid id)
        {
            return _context.POIs.Any(e => e.Id == id);
        }
    }
}
