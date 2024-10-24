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
    public class AceptacionesCotizacionController : ControllerBase
    {
        private readonly AdminSoftliContext _context;

        public AceptacionesCotizacionController(AdminSoftliContext context)
        {
            _context = context;
        }

        // GET: api/aceptacionescotizacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AceptacionesCotizacion>>> GetAceptacionesCotizacion()
        {
            return await _context.AceptacionesCotizacions.ToListAsync();
        }

        // GET: api/aceptacionescotizacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AceptacionesCotizacion>> GetAceptacionCotizacion(int id)
        {
            var aceptacion = await _context.AceptacionesCotizacions.FindAsync(id);

            if (aceptacion == null)
            {
                return NotFound();
            }

            return aceptacion;
        }

        // POST: api/aceptacionescotizacion
        [HttpPost]
        public async Task<ActionResult<AceptacionesCotizacion>> PostAceptacionCotizacion(AceptacionesCotizacion aceptacion)
        {
            _context.AceptacionesCotizacions.Add(aceptacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAceptacionCotizacion), new { id = aceptacion.IdAceptacion }, aceptacion);
        }

        // PUT: api/aceptacionescotizacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAceptacionCotizacion(int id, AceptacionesCotizacion aceptacion)
        {
            if (id != aceptacion.IdAceptacion)
            {
                return BadRequest();
            }

            _context.Entry(aceptacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AceptacionCotizacionExists(id))
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

        // DELETE: api/aceptacionescotizacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAceptacionCotizacion(int id)
        {
            var aceptacion = await _context.AceptacionesCotizacions.FindAsync(id);
            if (aceptacion == null)
            {
                return NotFound();
            }

            _context.AceptacionesCotizacions.Remove(aceptacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AceptacionCotizacionExists(int id)
        {
            return _context.AceptacionesCotizacions.Any(e => e.IdAceptacion == id);
        }
    }
}
