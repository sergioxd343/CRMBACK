using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_admin.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace crm_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuejasSugerenciaController : ControllerBase
    {
        private readonly AdminSoftliContext _context;

        public QuejasSugerenciaController(AdminSoftliContext context)
        {
            _context = context;
        }

        // GET: api/QuejasSugerencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuejasSugerencia>>> GetQuejasSugerencias()
        {
            return await _context.QuejasSugerencias
                .Include(q => q.IdClienteNavigation)
                .Include(q => q.IdUsuarioNavigation)
                .ToListAsync();
        }

        // GET: api/QuejasSugerencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuejasSugerencia>> GetQuejasSugerencia(int id)
        {
            var quejasSugerencia = await _context.QuejasSugerencias
                .Include(q => q.IdClienteNavigation)
                .Include(q => q.IdUsuarioNavigation)
                .FirstOrDefaultAsync(q => q.IdQuejaSugerencia == id);

            if (quejasSugerencia == null)
            {
                return NotFound();
            }

            return quejasSugerencia;
        }

        // POST: api/QuejasSugerencia
        [HttpPost]
        public async Task<ActionResult<QuejasSugerencia>> PostQuejasSugerencia(QuejasSugerencia quejasSugerencia)
        {
            _context.QuejasSugerencias.Add(quejasSugerencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuejasSugerencia), new { id = quejasSugerencia.IdQuejaSugerencia }, quejasSugerencia);
        }

        // PUT: api/QuejasSugerencia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuejasSugerencia(int id, QuejasSugerencia quejasSugerencia)
        {
            if (id != quejasSugerencia.IdQuejaSugerencia)
            {
                return BadRequest();
            }

            _context.Entry(quejasSugerencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuejasSugerenciaExists(id))
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

        // DELETE: api/QuejasSugerencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuejasSugerencia(int id)
        {
            var quejasSugerencia = await _context.QuejasSugerencias.FindAsync(id);
            if (quejasSugerencia == null)
            {
                return NotFound();
            }

            _context.QuejasSugerencias.Remove(quejasSugerencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuejasSugerenciaExists(int id)
        {
            return _context.QuejasSugerencias.Any(e => e.IdQuejaSugerencia == id);
        }
    }
}
