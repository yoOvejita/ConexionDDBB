using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConexionDDBB.Conexion;
using ConexionDDBB.Models;

namespace ConexionDDBB.Controllers
{
    public class VentaController : Controller
    {
        private readonly EmpresaXDbContext _context;

        public VentaController(EmpresaXDbContext context)
        {
            _context = context;
        }

        // GET: Venta
        public async Task<IActionResult> Index()
        {
            var empresaXDbContext = _context.Ventas.Include(v => v.cliente).Include(v => v.empleado).Include(v => v.producto);
            return View(await empresaXDbContext.ToListAsync());
        }

        // GET: Venta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.cliente)
                .Include(v => v.empleado)
                .Include(v => v.producto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Venta/Create
        public IActionResult Create()
        {
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "nit", "apellido");
            ViewData["id_empleado"] = new SelectList(_context.Empleados, "ci", "apellido");
            ViewData["id_producto"] = new SelectList(_context.Productos, "id_prod", "id_prod");
            return View();
        }

        // POST: Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_cliente,id_empleado,id_producto,fecha_venta")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "nit", "apellido", venta.id_cliente);
            ViewData["id_empleado"] = new SelectList(_context.Empleados, "ci", "apellido", venta.id_empleado);
            ViewData["id_producto"] = new SelectList(_context.Productos, "id_prod", "id_prod", venta.id_producto);
            return View(venta);
        }

        // GET: Venta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "nit", "apellido", venta.id_cliente);
            ViewData["id_empleado"] = new SelectList(_context.Empleados, "ci", "apellido", venta.id_empleado);
            ViewData["id_producto"] = new SelectList(_context.Productos, "id_prod", "id_prod", venta.id_producto);
            return View(venta);
        }

        // POST: Venta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,id_cliente,id_empleado,id_producto,fecha_venta")] Venta venta)
        {
            if (id != venta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "nit", "apellido", venta.id_cliente);
            ViewData["id_empleado"] = new SelectList(_context.Empleados, "ci", "apellido", venta.id_empleado);
            ViewData["id_producto"] = new SelectList(_context.Productos, "id_prod", "id_prod", venta.id_producto);
            return View(venta);
        }

        // GET: Venta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.cliente)
                .Include(v => v.empleado)
                .Include(v => v.producto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.id == id);
        }
    }
}
