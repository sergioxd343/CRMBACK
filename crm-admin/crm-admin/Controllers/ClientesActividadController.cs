using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_admin.Models;

namespace crm_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesActividadController : ControllerBase
    {
        private readonly AdminSoftliContext _context;

        public ClientesActividadController(AdminSoftliContext context)
        {
            _context = context;
        }

        // GET: api/clientesactividad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientesActividad>>> GetClientesActividad()
        {
            return await _context.ClientesActividads.ToListAsync();
        }

        // GET: api/clientesactividad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientesActividad>> GetClientesActividad(int id)
        {
            var actividad = await _context.ClientesActividads.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // POST: api/clientesactividad
        [HttpPost]
        public async Task<ActionResult<ClientesActividad>> PostClientesActividad(ClientesActividad actividad)
        {
            _context.ClientesActividads.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientesActividad), new { id = actividad.IdActividadCliente }, actividad);
        }

        // PUT: api/clientesactividad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientesActividad(int id, ClientesActividad actividad)
        {
            if (id != actividad.IdActividadCliente)
            {
                return BadRequest();
            }

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesActividadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/clientesactividad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientesActividad(int id)
        {
            var actividad = await _context.ClientesActividads.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.ClientesActividads.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesActividadExists(int id)
        {
            return _context.ClientesActividads.Any(e => e.IdActividadCliente == id);
        }
    }
}
