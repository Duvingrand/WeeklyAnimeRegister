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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configuración de la relación para Dropeados
    modelBuilder.Entity<Historial>()
        .HasMany(h => h.Dropeados)
        .WithOne()  // Sin propiedad de navegación inversa explícita en Serie
        .HasForeignKey("HistorialIdDropeados")
        .OnDelete(DeleteBehavior.Restrict);

    // Configuración de la relación para Terminados
    modelBuilder.Entity<Historial>()
        .HasMany(h => h.Terminados)
        .WithOne()
        .HasForeignKey("HistorialIdTerminados")
        .OnDelete(DeleteBehavior.Restrict);

    // Configuración de la relación para Proximos
    modelBuilder.Entity<Historial>()
        .HasMany(h => h.Proximos)
        .WithOne()
        .HasForeignKey("HistorialIdProximos")
        .OnDelete(DeleteBehavior.Restrict);
}


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
