using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPropio.Models;
using ProyectoPropio.data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ProyectoPropio.Views.Seried
{
    public class SeriedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeriedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seried
        public async Task<IActionResult> Index()
        {
            return View(await _context.Series.ToListAsync());
        }

        // GET: Seried/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        // GET: Seried/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seried/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Season,ActualEpisode,TotalOfEpisode,NetflixURL")] Serie serie, IFormFile ImagePath)
        {
            if (ModelState.IsValid)
            {
                // Procesar el archivo de imagen si se ha cargado uno
                if (ImagePath != null && ImagePath.Length > 0)
                {
                    // Definir la ruta donde se guardará la imagen
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", ImagePath.FileName);

                    // Guardar el archivo en la carpeta wwwroot/images
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImagePath.CopyToAsync(stream);
                    }

                    // Asignar la ruta de la imagen al modelo
                    serie.ImagePath = "/images/" + ImagePath.FileName;
                }

                // Guardar el objeto Serie en la base de datos
                _context.Add(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serie);
        }

        // GET: Seried/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            return View(serie);
        }

        // POST: Seried/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Season,ActualEpisode,TotalOfEpisode,NetflixURL,ImagePath")] Serie serie, IFormFile ImagePath)
        {
            if (id != serie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Procesar el archivo de imagen si se ha cargado uno
                    if (ImagePath != null && ImagePath.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", ImagePath.FileName);
                        
                        // Guardar el archivo en la carpeta wwwroot/images
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImagePath.CopyToAsync(stream);
                        }

                        // Asignar la ruta de la imagen al modelo
                        serie.ImagePath = "/images/" + ImagePath.FileName;
                    }

                    _context.Update(serie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerieExists(serie.Id))
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
            return View(serie);
        }

        // GET: Seried/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        // POST: Seried/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie != null)
            {
                _context.Series.Remove(serie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}

