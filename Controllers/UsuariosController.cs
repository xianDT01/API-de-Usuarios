using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCrud.Data;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            var usuariosDTO = usuarios.Select(u => new UsuarioDTO
            {
                Nombre = u.Nombre,
                CorreoElectronico = u.CorreoElectronico,
                FechaDeAlta = u.FechaDeAlta,
                Activo = u.Activo
            });

            return Ok(usuariosDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDTO = new UsuarioDTO
            {
                Nombre = usuario.Nombre,
                CorreoElectronico = usuario.CorreoElectronico,
                FechaDeAlta = usuario.FechaDeAlta,
                Activo = usuario.Activo
            };

            return Ok(usuarioDTO);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario(UsuarioCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                CorreoElectronico = dto.CorreoElectronico,
                PasswordHash = dto.PasswordHash,
                Activo = dto.Activo,
                FechaDeAlta = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, null);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID no coincide.");

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            usuario.Nombre = dto.Nombre ?? usuario.Nombre;
            usuario.CorreoElectronico = dto.CorreoElectronico ?? usuario.CorreoElectronico;
            usuario.Activo = dto.Activo;

            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
