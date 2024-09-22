using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Models;

namespace RentACarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransmissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Transmissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transmission>>> GetTransmissions()
        {
            return await _context.Transmissions.ToListAsync();
        }

        // GET: api/Transmissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transmission>> GetTransmission(int id)
        {
            var transmission = await _context.Transmissions.FindAsync(id);

            if (transmission == null)
            {
                return NotFound();
            }

            return transmission;
        }

        // PUT: api/Transmissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransmission(int id, Transmission transmission)
        {
            if (id != transmission.Id)
            {
                return BadRequest();
            }

            _context.Entry(transmission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransmissionExists(id))
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

        // POST: api/Transmissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transmission>> PostTransmission(Transmission transmission)
        {
            _context.Transmissions.Add(transmission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransmission", new { id = transmission.Id }, transmission);
        }

        // DELETE: api/Transmissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransmission(int id)
        {
            var transmission = await _context.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                return NotFound();
            }

            _context.Transmissions.Remove(transmission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransmissionExists(int id)
        {
            return _context.Transmissions.Any(e => e.Id == id);
        }
    }
}
