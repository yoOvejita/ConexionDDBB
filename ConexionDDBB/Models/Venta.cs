using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConexionDDBB.Models
{
    [Table("venta")]
    public class Venta
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public int id_cliente { get; set; }
        [Required]
        public int id_empleado { get; set; }
        [Required]
        public int id_producto { get; set; }
        public DateTime fecha_venta { get; set; }

        public virtual Cliente cliente { get; set; }
        public virtual Empleado empleado { get; set; }
        public virtual Producto producto { get; set; }
    }
}
