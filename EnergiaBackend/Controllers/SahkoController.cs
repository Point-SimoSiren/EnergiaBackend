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
    public class SahkoController : ControllerBase
    {
        private readonly EnergiaDBContext _context = new EnergiaDBContext();

        // GET: api/Sahko
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sahko>>> GetSahkos()
        {
            return await _context.Sahkos.ToListAsync();
        }

        // GET: api/Sahko/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sahko>> GetSahko(int id)
        {
            var sahko = await _context.Sahkos.FindAsync(id);

            if (sahko == null)
            {
                return NotFound();
            }

            return sahko;
        }

        // PUT: api/Sahko/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSahko(int id, Sahko sahko)
        {
            if (id != sahko.SahkoId)
            {
                return BadRequest();
            }

            _context.Entry(sahko).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SahkoExists(id))
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

        // POST: api/Sahko
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sahko>> PostSahko(Sahko sahko)
        {
            _context.Sahkos.Add(sahko);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSahko", new { id = sahko.SahkoId }, sahko);
        }

        // DELETE: api/Sahko/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSahko(int id)
        {
            var sahko = await _context.Sahkos.FindAsync(id);
            if (sahko == null)
            {
                return NotFound();
            }

            _context.Sahkos.Remove(sahko);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SahkoExists(int id)
        {
            return _context.Sahkos.Any(e => e.SahkoId == id);
        }
    }
}
