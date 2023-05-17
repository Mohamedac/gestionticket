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
    public class MembreSupportTechniquesController : Controller
    {
        private readonly gestionticketContext _context;

        public MembreSupportTechniquesController(gestionticketContext context)
        {
            _context = context;
        }

        // GET: MembreSupportTechniques
        public async Task<IActionResult> Index()
        {
              return _context.MembreSupportTechnique != null ? 
                          View(await _context.MembreSupportTechnique.ToListAsync()) :
                          Problem("Entity set 'gestionticketContext.MembreSupportTechnique'  is null.");
        }

        // GET: MembreSupportTechniques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembreSupportTechnique == null)
            {
                return NotFound();
            }

            var membreSupportTechnique = await _context.MembreSupportTechnique
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membreSupportTechnique == null)
            {
                return NotFound();
            }

            return View(membreSupportTechnique);
        }

        // GET: MembreSupportTechniques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembreSupportTechniques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,MotDePasse")] MembreSupportTechnique membreSupportTechnique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membreSupportTechnique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membreSupportTechnique);
        }

        // GET: MembreSupportTechniques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MembreSupportTechnique == null)
            {
                return NotFound();
            }

            var membreSupportTechnique = await _context.MembreSupportTechnique.FindAsync(id);
            if (membreSupportTechnique == null)
            {
                return NotFound();
            }
            return View(membreSupportTechnique);
        }

        // POST: MembreSupportTechniques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,MotDePasse")] MembreSupportTechnique membreSupportTechnique)
        {
            if (id != membreSupportTechnique.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membreSupportTechnique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembreSupportTechniqueExists(membreSupportTechnique.Id))
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
            return View(membreSupportTechnique);
        }

        // GET: MembreSupportTechniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembreSupportTechnique == null)
            {
                return NotFound();
            }

            var membreSupportTechnique = await _context.MembreSupportTechnique
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membreSupportTechnique == null)
            {
                return NotFound();
            }

            return View(membreSupportTechnique);
        }

        // POST: MembreSupportTechniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MembreSupportTechnique == null)
            {
                return Problem("Entity set 'gestionticketContext.MembreSupportTechnique'  is null.");
            }
            var membreSupportTechnique = await _context.MembreSupportTechnique.FindAsync(id);
            if (membreSupportTechnique != null)
            {
                _context.MembreSupportTechnique.Remove(membreSupportTechnique);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembreSupportTechniqueExists(int id)
        {
          return (_context.MembreSupportTechnique?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
