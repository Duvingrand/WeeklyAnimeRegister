using Microsoft.EntityFrameworkCore;
using ProyectoPropio.Models;

namespace ProyectoPropio.data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Definición de DbSet para cada modelo
    public DbSet<Serie> Series { get; set; }
    public DbSet<Dias> Dias { get; set; }
}
