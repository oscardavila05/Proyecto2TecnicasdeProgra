using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Data;
using MiProyectoMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Marca,PrecioCompra,PrecioVenta")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto); // El valor de 'Id' se gestiona automáticamente
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }
    }
}
