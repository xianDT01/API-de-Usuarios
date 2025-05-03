using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCrud.Data;
using WebApiCrud.Models;
using WebApiCrud.Services;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

         private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _service.GetAllAsync();
            var dtoList = usuarios.Select(u => new UsuarioDTO
            {
                Nombre = u.Nombre,
                CorreoElectronico = u.CorreoElectronico,
                FechaDeAlta = u.FechaDeAlta,
                Activo = u.Activo
            });

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            var dto = new UsuarioDTO
            {
                Nombre = usuario.Nombre,
                CorreoElectronico = usuario.CorreoElectronico,
                FechaDeAlta = usuario.FechaDeAlta,
                Activo = usuario.Activo
            };

            return Ok(dto);
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

            await _service.AddAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuario(int id, UsuarioUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID no coincide.");

            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            usuario.Nombre = dto.Nombre ?? usuario.Nombre;
            usuario.CorreoElectronico = dto.CorreoElectronico ?? usuario.CorreoElectronico;
            usuario.Activo = dto.Activo;

            await _service.UpdateAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            await _service.DeleteAsync(usuario);
            return NoContent();
        }
    }
    }

