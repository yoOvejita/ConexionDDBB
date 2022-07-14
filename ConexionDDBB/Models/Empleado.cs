using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ConexionDDBB.Models
{
    [Table("empleado")]
    public class Empleado
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ci { get; set; }
        [Required]
        [MaxLength(40)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(40)]
        public string apellido { get; set; }
        public int telefono { get; set; }
        [MaxLength(70)]
        [EmailAddress]
        public string email { get; set; }

        public virtual ICollection<Venta> ventas { get; set; }

        public Empleado()
        {
            ventas = new HashSet<Venta>();
        }
    }
}
