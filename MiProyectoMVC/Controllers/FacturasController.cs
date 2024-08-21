using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Data;
using MiProyectoMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoMVC.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Facturas/Create
        /// </summary>
        /// <returns></returns>

        
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Facturas/Create
        /// </summary>
        /// <param name="factura"></param>
        /// <returns></returns>

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cliente,Producto,PrecioProducto,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(factura);
        }

        

        /// <summary>
        /// GET: Facturas
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var facturas = await _context.Facturas.ToListAsync();
            return View(facturas);
        }

        

        /// <summary>
        /// GET: Facturas/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        /// <summary>
        /// POST: Facturas/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
