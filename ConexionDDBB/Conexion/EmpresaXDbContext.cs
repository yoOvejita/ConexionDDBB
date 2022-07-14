using ConexionDDBB.Models;
using Microsoft.EntityFrameworkCore;

namespace ConexionDDBB.Conexion
{
    public class EmpresaXDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public EmpresaXDbContext(DbContextOptions<EmpresaXDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relación Venta-Empleado
            modelBuilder.Entity<Venta>(entidad => 
            entidad.HasOne(ven => ven.empleado).WithMany(emp => emp.ventas)
            .HasForeignKey(ven => ven.id_empleado).HasConstraintName("venta_ibfk_2")
                );
            //Relación Venta-Cliente
            modelBuilder.Entity<Venta>(entidad =>
            entidad.HasOne(ven => ven.cliente).WithMany(cli => cli.ventas)
            .HasForeignKey(ven => ven.id_cliente).HasConstraintName("venta_ibfk_1")
                );
            //Relación Venta-Producto
            modelBuilder.Entity<Venta>(entidad =>
            entidad.HasOne(ven => ven.producto).WithMany(prod => prod.ventas)
            .HasForeignKey(ven => ven.id_producto).HasConstraintName("venta_ibfk_3")
                );
        }
    }
}
