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
    public class StatistiquesController : Controller
    {
        private readonly gestionticketContext _context;

        public StatistiquesController(gestionticketContext context)
        {
            _context = context;
        }

        // GET: Statistiques
        public async Task<IActionResult> Index()
        {
              return _context.Statistique != null ? 
                          View(await _context.Statistique.ToListAsync()) :
                          Problem("Entity set 'gestionticketContext.Statistique'  is null.");
        }

        // GET: Statistiques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Statistique == null)
            {
                return NotFound();
            }

            var statistiques = await _context.Statistique
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statistiques == null)
            {
                return NotFound();
            }

            return View(statistiques);
        }

        // GET: Statistiques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statistiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Valeur")] Statistiques statistiques)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statistiques);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statistiques);
        }

        // GET: Statistiques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Statistique == null)
            {
                return NotFound();
            }

            var statistiques = await _context.Statistique.FindAsync(id);
            if (statistiques == null)
            {
                return NotFound();
            }
            return View(statistiques);
        }

        // POST: Statistiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Valeur")] Statistiques statistiques)
        {
            if (id != statistiques.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statistiques);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatistiquesExists(statistiques.Id))
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
            return View(statistiques);
        }

        // GET: Statistiques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Statistique == null)
            {
                return NotFound();
            }

            var statistiques = await _context.Statistique
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statistiques == null)
            {
                return NotFound();
            }

            return View(statistiques);
        }

        // POST: Statistiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Statistique == null)
            {
                return Problem("Entity set 'gestionticketContext.Statistique'  is null.");
            }
            var statistiques = await _context.Statistique.FindAsync(id);
            if (statistiques != null)
            {
                _context.Statistique.Remove(statistiques);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatistiquesExists(int id)
        {
          return (_context.Statistique?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
