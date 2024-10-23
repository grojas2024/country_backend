using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfimaWebApi.Context;
using OfimaWebApi.Models;

namespace OfimaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPais()
        {
            return await _context.Pais.ToListAsync();
        }

        // GET: api/Pais/{codigo}
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Pais>> GetPais(string codigo)
        {
            var pais = await _context.Pais.FindAsync(codigo);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // PUT: api/Pais/{codigo}
        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutPais(string codigo, Pais pais)
        {
            if (codigo != pais.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(codigo))
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

        // POST: api/Pais
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            _context.Pais.Add(pais);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPais), new { codigo = pais.Codigo }, pais);
        }

        // DELETE: api/Pais/{codigo}
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeletePais(string codigo)
        {
            var pais = await _context.Pais.FindAsync(codigo);
            if (pais == null)
            {
                return NotFound();
            }

            _context.Pais.Remove(pais);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaisExists(string codigo)
        {
            return _context.Pais.Any(e => e.Codigo == codigo);
        }
    }
}
