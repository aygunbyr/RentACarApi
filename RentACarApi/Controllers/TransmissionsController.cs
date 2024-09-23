using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : ControllerBase
    {
        private readonly ITransmissionService _transmissionService;

        public TransmissionsController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        // GET: api/Transmissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transmission>>> GetTransmissions()
        {
            var transmissions = await _transmissionService.GetAllAsync();
            return Ok(transmissions);
        }

        // GET: api/Transmissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transmission>> GetTransmission(int id)
        {
            var transmission = await _transmissionService.GetByIdAsync(id);

            if (transmission == null)
            {
                return NotFound();
            }

            return Ok(transmission);
        }

        // PUT: api/Transmissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransmission(int id, Transmission transmission)
        {
            if (id != transmission.Id)
            {
                return BadRequest();
            }

            var existingTransmission = await _transmissionService.GetByIdAsync(id);
            if (existingTransmission == null)
            {
                return NotFound();
            }

            await _transmissionService.UpdateAsync(transmission);

            return NoContent();
        }

        // POST: api/Transmissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transmission>> PostTransmission(Transmission transmission)
        {
            await _transmissionService.AddAsync(transmission);

            return CreatedAtAction("GetTransmission", new { id = transmission.Id }, transmission);
        }

        // DELETE: api/Transmissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransmission(int id)
        {
            var transmission = await _transmissionService.GetByIdAsync(id);
            if (transmission == null)
            {
                return NotFound();
            }

            await _transmissionService.DeleteAsync(transmission);

            return NoContent();
        }
    }
}
