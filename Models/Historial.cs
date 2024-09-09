using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropio.Models
{
    [Table("historial")]
    public class Historial
    {
        [Key]
        public int Id { get; set; }

        // Relación con las series dropeadas
        public List<Serie>? Dropeados { get; set; } = new List<Serie>();
        
        // Relación con las series terminadas
        public List<Serie>? Terminados { get; set; } = new List<Serie>();
        
        // Relación con las series proximas
        public List<Serie>? Proximos { get; set; } = new List<Serie>();
    }
}
