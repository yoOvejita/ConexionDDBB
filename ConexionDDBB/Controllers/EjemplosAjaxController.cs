using ConexionDDBB.Conexion;
using ConexionDDBB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ConexionDDBB.Controllers
{
    public class EjemplosAjaxController : Controller
    {
        private EmpresaXDbContext ddbb;
        public EjemplosAjaxController(EmpresaXDbContext _ddbb) {
            ddbb = _ddbb;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ContentResult Ejemplo1()
        {
            return Content("Vengo desde el controlador!","text/plain");
        }
        [Route("Ejemplo2/{nombrecito}")]
        public ContentResult Ejemplo2(string nombrecito)
        {
            return Content("Hola " + nombrecito, "text/plain");
        }
        public IActionResult Ejemplo3() {
            Producto prod = new Producto() { 
                id_prod= 333,
                nombre = "Atun verriel",
                precio = 20
            };
            return new JsonResult(prod);
        }
        public IActionResult Ejemplo4()
        {
            var productos = new List<Producto>() {
                new Producto()
            {
                id_prod = 11,
                nombre = "Papas fritas",
                precio = 12
            },
                new Producto()
            {
                id_prod = 22,
                nombre = "Gaseosa 3L",
                precio = 10
            },
                new Producto()
            {
                id_prod = 33,
                nombre = "Cereales con azucar",
                precio = 25
            },
                new Producto()
            {
                id_prod = 44,
                nombre = "Pipocas",
                precio = 8
            }
            };

            var prods = ddbb.Productos.Where(p => p.precio > 15).ToList();
            
            return new JsonResult(prods);
        }
    }
}
