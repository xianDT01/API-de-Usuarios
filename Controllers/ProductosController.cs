using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiCrud.Data;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly DataContext _context;

        public ProductosController(ILogger<ProductosController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();

            var productosDTO = productos.Select(p => new ProductoDTO
            {
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                FechaDeAlta = p.FechaDeAlta,
                Precio = p.Precio,
                Activo = p.Activo
            });

            return Ok(productosDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            var productoDTO = new ProductoDTO
            {
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                FechaDeAlta = producto.FechaDeAlta,
                Precio = producto.Precio,
                Activo = producto.Activo
            };

            return Ok(productoDTO);
        }

        [HttpPost]
        public async Task<ActionResult> PostProducto(ProductoCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Activo = dto.Activo,
                FechaDeAlta = DateTime.UtcNow
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, null);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, ProductoUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID no coincide.");

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            producto.Nombre = dto.Nombre ?? producto.Nombre;
            producto.Descripcion = dto.Descripcion ?? producto.Descripcion;
            producto.Precio = dto.Precio;
            producto.Activo = dto.Activo;

            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound("No se encontró ningún producto con ese ID.");
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
