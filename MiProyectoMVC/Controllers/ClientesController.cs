using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Data;
using MiProyectoMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MiProyectoMVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Email,Telefono,FechaAlta")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente); // El valor de 'Id' se gestionará automáticamente
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }


        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }
    }
}
