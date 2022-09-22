using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergiaBackend.Models;

namespace EnergiaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaukolampoController : ControllerBase
    {
        private readonly EnergiaDBContext _context = new EnergiaDBContext();

      

        // GET: api/Kaukolampo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kaukolampo>>> GetKaukolampos()
        {
            return await _context.Kaukolampos.ToListAsync();
        }

        // GET: api/Kaukolampo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kaukolampo>> GetKaukolampo(int id)
        {
            var kaukolampo = await _context.Kaukolampos.FindAsync(id);

            if (kaukolampo == null)
            {
                return NotFound();
            }

            return kaukolampo;
        }

        // PUT: api/Kaukolampo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKaukolampo(int id, Kaukolampo kaukolampo)
        {
            if (id != kaukolampo.KaukolampoId)
            {
                return BadRequest();
            }

            _context.Entry(kaukolampo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KaukolampoExists(id))
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

        // POST: api/Kaukolampo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kaukolampo>> PostKaukolampo(Kaukolampo kaukolampo)
        {
            _context.Kaukolampos.Add(kaukolampo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKaukolampo", new { id = kaukolampo.KaukolampoId }, kaukolampo);
        }

        // DELETE: api/Kaukolampo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKaukolampo(int id)
        {
            var kaukolampo = await _context.Kaukolampos.FindAsync(id);
            if (kaukolampo == null)
            {
                return NotFound();
            }

            _context.Kaukolampos.Remove(kaukolampo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KaukolampoExists(int id)
        {
            return _context.Kaukolampos.Any(e => e.KaukolampoId == id);
        }
    }
}
