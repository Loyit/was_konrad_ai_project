using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rezerwacja_pokoi.Data;
using Rezerwacja_pokoi.Models;

namespace Rezerwacja_pokoi.Controllers
{
    public class ConveniencesController : Controller
    {
        private readonly HotelContext _context;

        public ConveniencesController(HotelContext context)
        {
            _context = context;
        }

        // GET: Conveniences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conveniences.ToListAsync());
        }

        // GET: Conveniences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenience = await _context.Conveniences
                .FirstOrDefaultAsync(m => m.ID == id);
            if (convenience == null)
            {
                return NotFound();
            }

            return View(convenience);
        }

        // GET: Conveniences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conveniences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Price")] Convenience convenience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convenience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convenience);
        }

        // GET: Conveniences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenience = await _context.Conveniences.FindAsync(id);
            if (convenience == null)
            {
                return NotFound();
            }
            return View(convenience);
        }

        // POST: Conveniences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Price")] Convenience convenience)
        {
            if (id != convenience.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convenience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvenienceExists(convenience.ID))
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
            return View(convenience);
        }

        // GET: Conveniences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenience = await _context.Conveniences
                .FirstOrDefaultAsync(m => m.ID == id);
            if (convenience == null)
            {
                return NotFound();
            }

            return View(convenience);
        }

        // POST: Conveniences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convenience = await _context.Conveniences.FindAsync(id);
            _context.Conveniences.Remove(convenience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvenienceExists(int id)
        {
            return _context.Conveniences.Any(e => e.ID == id);
        }
    }
}
