using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_admin.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace crm_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreciosServiciosPreestablecidoController : ControllerBase
    {
        private readonly AdminSoftliContext _context;

        public PreciosServiciosPreestablecidoController(AdminSoftliContext context)
        {
            _context = context;
        }

        // GET: api/PreciosServiciosPreestablecido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreciosServiciosPreestablecido>>> GetPreciosServiciosPreestablecidos()
        {
            return await _context.PreciosServiciosPreestablecidos
                .Include(p => p.IdServicioNavigation)
                .ToListAsync();
        }

        // GET: api/PreciosServiciosPreestablecido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreciosServiciosPreestablecido>> GetPreciosServiciosPreestablecido(int id)
        {
            var precioServicio = await _context.PreciosServiciosPreestablecidos
                .Include(p => p.IdServicioNavigation)
                .FirstOrDefaultAsync(p => p.IdPrecio == id);

            if (precioServicio == null)
            {
                return NotFound();
            }

            return precioServicio;
        }

        // POST: api/PreciosServiciosPreestablecido
        [HttpPost]
        public async Task<ActionResult<PreciosServiciosPreestablecido>> PostPreciosServiciosPreestablecido(PreciosServiciosPreestablecido preciosServiciosPreestablecido)
        {
            _context.PreciosServiciosPreestablecidos.Add(preciosServiciosPreestablecido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreciosServiciosPreestablecido), new { id = preciosServiciosPreestablecido.IdPrecio }, preciosServiciosPreestablecido);
        }

        // PUT: api/PreciosServiciosPreestablecido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreciosServiciosPreestablecido(int id, PreciosServiciosPreestablecido preciosServiciosPreestablecido)
        {
            if (id != preciosServiciosPreestablecido.IdPrecio)
            {
                return BadRequest();
            }

            _context.Entry(preciosServiciosPreestablecido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreciosServiciosPreestablecidoExists(id))
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

        // DELETE: api/PreciosServiciosPreestablecido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreciosServiciosPreestablecido(int id)
        {
            var preciosServiciosPreestablecido = await _context.PreciosServiciosPreestablecidos.FindAsync(id);
            if (preciosServiciosPreestablecido == null)
            {
                return NotFound();
            }

            _context.PreciosServiciosPreestablecidos.Remove(preciosServiciosPreestablecido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreciosServiciosPreestablecidoExists(int id)
        {
            return _context.PreciosServiciosPreestablecidos.Any(e => e.IdPrecio == id);
        }
    }
}
