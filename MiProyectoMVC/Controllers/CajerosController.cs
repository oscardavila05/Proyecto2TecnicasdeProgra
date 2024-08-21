using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Data;
using MiProyectoMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoMVC.Controllers
{
    public class CajerosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CajerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Cajeros/Create
        /// </summary>
        /// <returns></returns>

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Turno,FechaIngreso,Salario")] Cajero cajero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cajero); 
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cajero);
        }

        /// <summary>
        /// GET: Cajeros
        /// </summary>
        /// <returns></returns>

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cajeros.ToListAsync());
        }

        /// <summary>
        /// GET: Cajeros/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cajero = await _context.Cajeros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cajero == null)
            {
                return NotFound();
            }

            return View(cajero);
        }

        /// <summary>
        /// POST: Cajeros/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cajero = await _context.Cajeros.FindAsync(id);
            if (cajero != null)
            {
                _context.Cajeros.Remove(cajero);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
