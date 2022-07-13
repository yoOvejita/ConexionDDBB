using ConexionDDBB.Models;
using Microsoft.EntityFrameworkCore;

namespace ConexionDDBB.Conexion
{
    public class EmpresaXDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public EmpresaXDbContext(DbContextOptions<EmpresaXDbContext> options) : base(options) { }
    }
}
