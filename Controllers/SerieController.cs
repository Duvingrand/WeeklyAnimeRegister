using Microsoft.AspNetCore.Mvc;
using ProyectoPropio.Models;
using ProyectoPropio.data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPropio.Controllers
{
    public class SerieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SerieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Serie
        public async Task<IActionResult> Index()
        {
            var series = await _context.Series.ToListAsync();
            return View(series);
        }

        // GET: Serie/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var serie = await _context.Series
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        // GET: Serie/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            return View(serie);
        }

        // POST: Serie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Season,ActualEpisode,TotalOfEpisode,NetflixURL,ImagePath")] Serie serie)
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

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
