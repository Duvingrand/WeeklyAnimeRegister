using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPropio.Models;
using ProyectoPropio.data;

namespace ProyectoPropio.Controllers
{
    public class DiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dias.ToListAsync());
        }

        // GET: Dias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dias = await _context.Dias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dias == null)
            {
                return NotFound();
            }

            return View(dias);
        }

        // GET: Dias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Dias dias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dias);
        }

        // GET: Dias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dias = await _context.Dias.FindAsync(id);
            if (dias == null)
            {
                return NotFound();
            }
            return View(dias);
        }

        // POST: Dias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Dias dias)
        {
            if (id != dias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiasExists(dias.Id))
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
            return View(dias);
        }

        // GET: Dias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dias = await _context.Dias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dias == null)
            {
                return NotFound();
            }

            return View(dias);
        }

        // POST: Dias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dias = await _context.Dias.FindAsync(id);
            if (dias != null)
            {
                _context.Dias.Remove(dias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiasExists(int id)
        {
            return _context.Dias.Any(e => e.Id == id);
        }
    }
}
