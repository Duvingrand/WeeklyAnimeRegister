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
        public List<Serie>? Dropeados  { get; set; }
        public List<Serie>? Terminados  { get; set; }
        public List<Serie>? Proximos  { get; set; }
    }
}