using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_admin.Models;

namespace crm_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteraccionesController : ControllerBase
    {
        private readonly AdminSoftliContext _context;

        public InteraccionesController(AdminSoftliContext context)
        {
            _context = context;
        }

        // GET: api/interacciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interaccione>>> GetInteracciones()
        {
            return await _context.Interacciones
                .Include(i => i.IdClienteNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .ToListAsync();
        }

        // GET: api/interacciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interaccione>> GetInteraccion(int id)
        {
            var interaccion = await _context.Interacciones
                .Include(i => i.IdClienteNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .FirstOrDefaultAsync(i => i.IdInteraccion == id);

            if (interaccion == null)
            {
                return NotFound();
            }

            return interaccion;
        }

        // POST: api/interacciones
        [HttpPost]
        public async Task<ActionResult<Interaccione>> PostInteraccion(Interaccione interaccion)
        {
            _context.Interacciones.Add(interaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInteraccion), new { id = interaccion.IdInteraccion }, interaccion);
        }

        // PUT: api/interacciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteraccion(int id, Interaccione interaccion)
        {
            if (id != interaccion.IdInteraccion)
            {
                return BadRequest();
            }

            _context.Entry(interaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteraccionExists(id))
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

        // DELETE: api/interacciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInteraccion(int id)
        {
            var interaccion = await _context.Interacciones.FindAsync(id);
            if (interaccion == null)
            {
                return NotFound();
            }

            _context.Interacciones.Remove(interaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InteraccionExists(int id)
        {
            return _context.Interacciones.Any(e => e.IdInteraccion == id);
        }
    }
}
