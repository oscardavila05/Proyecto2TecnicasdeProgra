using Microsoft.EntityFrameworkCore;
using MiProyectoMVC.Models;
using System.Collections.Generic;

namespace MiProyectoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Cajero> Cajeros { get; set; }

        public DbSet<Producto> Productos { get; set; }
    }
}
