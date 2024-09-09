using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoPropio.Models
{
    [Table("series")]
    public class Serie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la serie es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "La temporada es obligatoria")]
        [StringLength(50, ErrorMessage = "La temporada no puede exceder los 50 caracteres")]
        public required string Season { get; set; }

        [Required(ErrorMessage = "El episodio actual es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El episodio actual debe ser un número positivo")]
        public int ActualEpisode { get; set; }

        [Required(ErrorMessage = "El total de episodios es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El total de episodios debe ser un número positivo")]
        public int TotalOfEpisode { get; set; }

        [Required(ErrorMessage = "La URL de Netflix es obligatoria")]
        [Url(ErrorMessage = "La URL de Netflix no es válida")]
        public required string NetflixURL { get; set; }

        public string? ImagePath { get; set; } // Esto no es obligatorio

        // Clave foránea a Historial, y diferenciación de la lista
        public int? HistorialId { get; set; } // Esto indica a qué Historial pertenece
        public Historial? Historial { get; set; }

        public string? ListType { get; set; } // Dropeados, Terminados, Proximos
    }
}

