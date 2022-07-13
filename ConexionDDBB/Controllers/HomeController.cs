using ConexionDDBB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ConexionDDBB.Conexion;

namespace ConexionDDBB.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpresaXDbContext contexto;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, EmpresaXDbContext contexto)
        {
            _logger = logger;
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            var emps = contexto.Empleados.ToList();
            ViewBag.empleados = emps;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
