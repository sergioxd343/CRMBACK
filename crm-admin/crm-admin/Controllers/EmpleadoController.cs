using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crm_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly AdminSoftliContext _context;

        public EmpleadoController(AdminSoftliContext context)
        {
            _context = context;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            var empleados = await _context.Empleados.Include(e => e.IdUsuarioNavigation).ToListAsync();
            if (empleados == null || empleados.Count == 0)
            {
                return NoContent(); // Devuelve 204 si no hay empleados
            }

            return Ok(empleados); // Devuelve 200 con la lista de empleados
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(e => e.IdEmpleado == id);

            if (empleado == null)
            {
                return NotFound($"El empleado con ID {id} no existe.");
            }

            return Ok(empleado); // Devuelve 200 con los datos del empleado
        }

        // POST: api/Empleado
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest("Los datos del empleado no pueden ser nulos.");
            }

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.IdEmpleado }, empleado);
        }

        // PUT: api/Empleado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest("Los datos del empleado no pueden ser nulos.");
            }

            if (id != empleado.IdEmpleado)
            {
                return BadRequest("El ID en la URL no coincide con el ID del empleado.");
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound($"No se encontró el empleado con ID {id}.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Devuelve 204 en caso de éxito
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound($"No se encontró el empleado con ID {id}.");
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return Ok($"El empleado con ID {id} ha sido eliminado."); // Devuelve 200 con el mensaje de éxito
        }

        // Método privado para verificar si el empleado existe
        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
