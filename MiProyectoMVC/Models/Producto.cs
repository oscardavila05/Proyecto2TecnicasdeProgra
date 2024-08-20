using System;
using System.ComponentModel.DataAnnotations;

namespace MiProyectoMVC.Models
{
    public class Producto
    {
        public int Id { get; set; } // Se gestiona automáticamente

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Range(0, 999999999.99)]
        public decimal PrecioCompra { get; set; }

        [Range(0, 999999999.99)]
        public decimal PrecioVenta { get; set; }
    }
}
