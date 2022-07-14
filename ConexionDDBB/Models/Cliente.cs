using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConexionDDBB.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Required]
        public int nit { get; set; }
        [Required]
        [MaxLength(30)]
        public string apellido { get; set; }
        public DateTime? fecha_inicio { get; set; }

        public virtual ICollection<Venta> ventas { get; set; }

        public Cliente()
        {
            ventas = new HashSet<Venta>();
        }
    }
}
