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
        private readonly ProductoService _service;

        public ProductosController(ProductoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            var productos = await _service.GetAllAsync();

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
            var producto = await _service.GetByIdAsync(id);
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

            await _service.AddAsync(producto);  
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, null);

        }



        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, ProductoUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID no coincide.");
            var producto = await _service.GetByIdAsync(id);

            if (producto == null)
                return NotFound();

            producto.Nombre = dto.Nombre ?? producto.Nombre;
            producto.Descripcion = dto.Descripcion ?? producto.Descripcion;
            producto.Precio = dto.Precio;
            producto.Activo = dto.Activo;

            await _service.UpdateAsync(producto);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            var producto = await _service.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound("No se encontró ningún producto con ese ID.");
            }
            await _service.DeleteAsync(producto);
            return NoContent();
        }
    }
}
