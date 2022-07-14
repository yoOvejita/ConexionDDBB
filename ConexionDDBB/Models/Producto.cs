using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConexionDDBB.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        public int id_prod { get; set; }
        [MaxLength(20)]
        public string nombre { get; set; }
        public int? precio { get; set; }

        public virtual ICollection<Venta> ventas { get; set; }

        public Producto()
        {
            ventas = new HashSet<Venta>();
        }
    }
}
