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
    public class ArchivoController : ControllerBase
    {
        private readonly AdminSoftliContext _context;

        public ArchivoController(AdminSoftliContext context)
        {
            _context = context;
        }

        // GET: api/archivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivo>>> GetArchivos()
        {
            return await _context.Archivos.ToListAsync();
        }

        // GET: api/archivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivo>> GetArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);

            if (archivo == null)
            {
                return NotFound();
            }

            return archivo;
        }

        // POST: api/archivo
        [HttpPost]
        public async Task<ActionResult<Archivo>> PostArchivo(Archivo archivo)
        {
            _context.Archivos.Add(archivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArchivo), new { id = archivo.IdArchivo }, archivo);
        }

        // PUT: api/archivo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivo(int id, Archivo archivo)
        {
            if (id != archivo.IdArchivo)
            {
                return BadRequest();
            }

            _context.Entry(archivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivoExists(id))
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

        // DELETE: api/archivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo == null)
            {
                return NotFound();
            }

            _context.Archivos.Remove(archivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchivoExists(int id)
        {
            return _context.Archivos.Any(e => e.IdArchivo == id);
        }
    }
}
