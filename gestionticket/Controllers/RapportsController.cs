using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestionticket.Data;
using gestionticket.Models;

namespace gestionticket.Controllers
{
    public class RapportsController : Controller
    {
        private readonly gestionticketContext _context;

        public RapportsController(gestionticketContext context)
        {
            _context = context;
        }

        // GET: Rapports
        public async Task<IActionResult> Index()
        {
              return _context.Rapport != null ? 
                          View(await _context.Rapport.ToListAsync()) :
                          Problem("Entity set 'gestionticketContext.Rapport'  is null.");
        }

        // GET: Rapports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rapport == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapport == null)
            {
                return NotFound();
            }

            return View(rapport);
        }

        // GET: Rapports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rapports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Date,Contenu")] Rapport rapport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rapport);
        }

        // GET: Rapports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rapport == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapport.FindAsync(id);
            if (rapport == null)
            {
                return NotFound();
            }
            return View(rapport);
        }

        // POST: Rapports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Date,Contenu")] Rapport rapport)
        {
            if (id != rapport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapportExists(rapport.Id))
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
            return View(rapport);
        }

        // GET: Rapports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rapport == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapport == null)
            {
                return NotFound();
            }

            return View(rapport);
        }

        // POST: Rapports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rapport == null)
            {
                return Problem("Entity set 'gestionticketContext.Rapport'  is null.");
            }
            var rapport = await _context.Rapport.FindAsync(id);
            if (rapport != null)
            {
                _context.Rapport.Remove(rapport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapportExists(int id)
        {
          return (_context.Rapport?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
