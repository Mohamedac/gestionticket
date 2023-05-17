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
    public class PrioritesController : Controller
    {
        private readonly gestionticketContext _context;

        public PrioritesController(gestionticketContext context)
        {
            _context = context;
        }

        // GET: Priorites
        public async Task<IActionResult> Index()
        {
              return _context.Priorite != null ? 
                          View(await _context.Priorite.ToListAsync()) :
                          Problem("Entity set 'gestionticketContext.Priorite'  is null.");
        }

        // GET: Priorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Priorite == null)
            {
                return NotFound();
            }

            var priorite = await _context.Priorite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priorite == null)
            {
                return NotFound();
            }

            return View(priorite);
        }

        // GET: Priorites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Priorites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Niveau,Nom")] Priorite priorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priorite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priorite);
        }

        // GET: Priorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Priorite == null)
            {
                return NotFound();
            }

            var priorite = await _context.Priorite.FindAsync(id);
            if (priorite == null)
            {
                return NotFound();
            }
            return View(priorite);
        }

        // POST: Priorites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Niveau,Nom")] Priorite priorite)
        {
            if (id != priorite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priorite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioriteExists(priorite.Id))
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
            return View(priorite);
        }

        // GET: Priorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Priorite == null)
            {
                return NotFound();
            }

            var priorite = await _context.Priorite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priorite == null)
            {
                return NotFound();
            }

            return View(priorite);
        }

        // POST: Priorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Priorite == null)
            {
                return Problem("Entity set 'gestionticketContext.Priorite'  is null.");
            }
            var priorite = await _context.Priorite.FindAsync(id);
            if (priorite != null)
            {
                _context.Priorite.Remove(priorite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioriteExists(int id)
        {
          return (_context.Priorite?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
