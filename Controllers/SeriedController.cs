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
            // Obtener la lista de días que no están ocupados
            var diasNoOcupados = _context.Dias
                .Where(d => !_context.Series.Any(s => s.DiaId == d.Id))
                .ToList();

            ViewBag.Dias = new SelectList(diasNoOcupados, "Id", "Name");
            return View();
        }

        // POST: Seried/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Name,Season,ActualEpisode,TotalOfEpisode,NetflixURL,DiaId")] Serie serie, IFormFile image)
{
    if (ModelState.IsValid)
    {
        // Comprobar si el archivo ha sido subido
        if (image != null && image.Length > 0)
        {
            // Definir la carpeta donde se guardará la imagen (wwwroot/imgs)
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgs");

            // Asegurar que la carpeta existe
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Crear un nombre único para la imagen
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            try
            {
                // Guardar la imagen en el servidor
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Guardar la ruta relativa en la propiedad ImagePath
                serie.ImagePath = "/imgs/" + uniqueFileName;
            }
            catch (Exception)
                    {
                // Manejar excepciones de archivo aquí (opcional)
                ModelState.AddModelError("", "No se pudo cargar la imagen. Inténtelo de nuevo.");
                return View(serie);
            }
        }

        // Añadir la serie al contexto y guardar los cambios
        _context.Add(serie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // Re-cargar la lista de días en caso de error
    var diasNoOcupados = _context.Dias
        .Where(d => !_context.Series.Any(s => s.DiaId == d.Id))
        .ToList();
    ViewBag.Dias = new SelectList(diasNoOcupados, "Id", "Name");

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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Season,ActualEpisode,TotalOfEpisode,NetflixURL,ImagePath,HistorialId")] Serie serie)
        {
            if (id != serie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
