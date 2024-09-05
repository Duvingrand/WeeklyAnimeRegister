using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropio.Models
{
    [Table("dias")]
    public class Dias
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        public List<Serie>? Historial { get; set; }
        public int AnimeOfTheDayId { get; set; } // Clave foránea

        [ForeignKey("AnimeOfTheDayId")]
        public required virtual Serie AnimeOfTheDay { get; set; } // Relación con el modelo Anime

    }
}