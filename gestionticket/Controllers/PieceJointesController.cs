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
    public class PieceJointesController : Controller
    {
        private readonly gestionticketContext _context;

        public PieceJointesController(gestionticketContext context)
        {
            _context = context;
        }

        // GET: PieceJointes
        public async Task<IActionResult> Index()
        {
              return _context.PieceJointe != null ? 
                          View(await _context.PieceJointe.ToListAsync()) :
                          Problem("Entity set 'gestionticketContext.PieceJointe'  is null.");
        }

        // GET: PieceJointes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PieceJointe == null)
            {
                return NotFound();
            }

            var pieceJointe = await _context.PieceJointe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceJointe == null)
            {
                return NotFound();
            }

            return View(pieceJointe);
        }

        // GET: PieceJointes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PieceJointes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Type,Contenu,DateUpload")] PieceJointe pieceJointe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieceJointe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieceJointe);
        }

        // GET: PieceJointes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PieceJointe == null)
            {
                return NotFound();
            }

            var pieceJointe = await _context.PieceJointe.FindAsync(id);
            if (pieceJointe == null)
            {
                return NotFound();
            }
            return View(pieceJointe);
        }

        // POST: PieceJointes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Type,Contenu,DateUpload")] PieceJointe pieceJointe)
        {
            if (id != pieceJointe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieceJointe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceJointeExists(pieceJointe.Id))
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
            return View(pieceJointe);
        }

        // GET: PieceJointes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PieceJointe == null)
            {
                return NotFound();
            }

            var pieceJointe = await _context.PieceJointe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceJointe == null)
            {
                return NotFound();
            }

            return View(pieceJointe);
        }

        // POST: PieceJointes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PieceJointe == null)
            {
                return Problem("Entity set 'gestionticketContext.PieceJointe'  is null.");
            }
            var pieceJointe = await _context.PieceJointe.FindAsync(id);
            if (pieceJointe != null)
            {
                _context.PieceJointe.Remove(pieceJointe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceJointeExists(int id)
        {
          return (_context.PieceJointe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
