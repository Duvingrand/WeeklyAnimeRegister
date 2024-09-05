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
    public DbSet<Historial> Historial { get; set; }

    // Configuración adicional del modelo
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // Configuración específica para la entidad Serie
    //     modelBuilder.Entity<Serie>()
    //         .ToTable("series");

    //     // Configuración específica para la entidad Dias
    //     modelBuilder.Entity<Dias>()
    //         .ToTable("Dias");

    //     // Puedes agregar más configuraciones aquí según sea necesario

    //     base.OnModelCreating(modelBuilder);
    // }
}
