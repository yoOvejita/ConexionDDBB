using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexionDDBB.Models
{
    [Table("empleado")]
    public class Empleado
    {
        [Key]
        [Required]
        public int ci { get; set; }
        [Required]
        [MaxLength(40)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(40)]
        public string apellido { get; set; }
        public int telefono { get; set; }
        [MaxLength(70)]
        public string email { get; set; }
    }
}
