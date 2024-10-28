using PruebaTecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Domain.Datos
{
    public class ConexionDBContext: DbContext
    {
        public ConexionDBContext(DbContextOptions<ConexionDBContext> options) : base(options) { }

        public DbSet<Cliente>? cliente { get; set; }
        public DbSet<Cuenta>? cuenta { get; set; }
        public DbSet<Movimiento>? movimiento { get; set; }

        public DbSet<Persona>? persona { get; set; }
    }
}
