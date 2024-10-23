using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfimaWebApi.Context;
using OfimaWebApi.Models;

namespace OfimaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CiudadController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ciudad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudad()
        {
            return Ok(await _context.Ciudad.ToListAsync());
        }

        // GET_CIUDAD: api/Ciudad/{codCiudad}
        [HttpGet("{codCiudad}")]
        public async Task<ActionResult<Ciudad>> GetCiudad(string codCiudad)
        {
            var ciudad = await _context.Ciudad.FindAsync(codCiudad);

            if (ciudad == null)
            {
                return NotFound(new { message = "Ciudad no encontrada" });
            }

            return Ok(ciudad);
        }

        // POST: api/Ciudad
        [HttpPost]
        public async Task<ActionResult<Ciudad>> PostCiudad(Ciudad ciudad)
        {
            _context.Ciudad.Add(ciudad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCiudad), new { codCiudad = ciudad.CodCiudad }, ciudad);
        }

        // PUT: api/Ciudad/{codCiudad}
        [HttpPut("{codCiudad}")]
        public async Task<IActionResult> PutCiudad(string codCiudad, Ciudad ciudad)
        {
            if (codCiudad != ciudad.CodCiudad)
            {
                return BadRequest(new { message = "Incongruencia de código" });
            }

            _context.Entry(ciudad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadExists(codCiudad))
                {
                    return NotFound(new { message = "Ciudad no encontrada" });
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Ciudad/{codCiudad}
        [HttpDelete("{codCiudad}")]
        public async Task<IActionResult> DeleteCiudad(string codCiudad)
        {
            var ciudad = await _context.Ciudad.FindAsync(codCiudad);
            if (ciudad == null)
            {
                return NotFound(new { message = "Ciudad no encontrada" });
            }

            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CiudadExists(string codCiudad)
        {
            return _context.Ciudad.Any(e => e.CodCiudad == codCiudad);
        }
    }
}
