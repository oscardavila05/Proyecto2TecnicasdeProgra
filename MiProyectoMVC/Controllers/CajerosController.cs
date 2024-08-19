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

        // GET: Cajeros/Create
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
                _context.Add(cajero); // El valor de 'Id' se gestiona automáticamente
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cajero);
        }

        // GET: Cajeros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cajeros.ToListAsync());
        }
    }
}
