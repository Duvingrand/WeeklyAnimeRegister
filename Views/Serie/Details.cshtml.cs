using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoPropio.Models;
using ProyectoPropio.data;

namespace ProyectoPropio.Views.SerieViews
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoPropio.data.ApplicationDbContext _context;

        public DetailsModel(ProyectoPropio.data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Serie Serie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series.FirstOrDefaultAsync(m => m.Id == id);
            if (serie == null)
            {
                return NotFound();
            }
            else
            {
                Serie = serie;
            }
            return Page();
        }
    }
}
