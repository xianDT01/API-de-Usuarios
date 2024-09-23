using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiCrud.Data; 
using WebApiCrud.Models; 

namespace WebApiCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly DataContext _context;

        public ProductosController(ILogger<ProductosController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto es nulo.");
            }

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("El ID del producto no coincide con el ID en la solicitud.");
            }

            if (producto == null)
            {
                return BadRequest("El producto es nulo.");
            }

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound("No se encontró ningún producto con el ID proporcionado.");
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
