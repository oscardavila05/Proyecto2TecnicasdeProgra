using System;
using System.ComponentModel.DataAnnotations;

namespace MiProyectoMVC.Models
{
    public class Cajero
    {
        public int Id { get; set; } // Se gestiona automáticamente

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Turno { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        [Range(0, 999999999.99)]
        public decimal Salario { get; set; }
    }
}
