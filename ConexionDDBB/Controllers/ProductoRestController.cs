using ConexionDDBB.Conexion;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionDDBB.Controllers
{
    [Route("api/prod")]
    public class ProductoRestController : Controller
    {
        private EmpresaXDbContext ddbb;
        public ProductoRestController(EmpresaXDbContext ddbb)
        {
            this.ddbb = ddbb;
        }
        [Produces("application/json")]
        [Route("buscar")]
        public async Task<IActionResult> Buscar()
        {
            try
            {
                string letras = HttpContext.Request.Query["term"].ToString();
                var nombres = ddbb.Productos.Where(prod => prod.nombre.Contains(letras)).Select(prod => prod.nombre).ToList();
                return Ok(nombres);
                     
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
