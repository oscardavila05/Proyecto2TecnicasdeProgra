using System.ComponentModel.DataAnnotations;

namespace MiProyectoMVC.Models
{
    public class Factura
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Producto { get; set; }

        [Required]
      
        public decimal PrecioProducto { get; set; }

        [Required]
        
        public decimal Total { get; set; }
    }
}
