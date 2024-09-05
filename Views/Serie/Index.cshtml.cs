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
    public class IndexModel : PageModel
    {
        private readonly ProyectoPropio.data.ApplicationDbContext _context;

        public IndexModel(ProyectoPropio.data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Serie> Serie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Serie = await _context.Series.ToListAsync();
        }
    }
}
