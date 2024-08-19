using System;
using System.ComponentModel.DataAnnotations;

namespace MiProyectoMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; } // La propiedad 'Id' se manejará automáticamente por la base de datos

        [Required]
        [StringLength(500)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }
    }
}