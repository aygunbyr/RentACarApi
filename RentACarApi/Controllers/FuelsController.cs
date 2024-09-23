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
    public class FuelsController : ControllerBase
    {
        private readonly IFuelService _fuelService;

        public FuelsController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        // GET: api/Fuels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fuel>>> GetFuels()
        {
            var fuels = await _fuelService.GetAllAsync();
            return Ok(fuels);
        }

        // GET: api/Fuels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fuel>> GetFuel(int id)
        {
            var fuel = await _fuelService.GetByIdAsync(id);

            if (fuel == null)
            {
                return NotFound();
            }

            return Ok(fuel);
        }

        // PUT: api/Fuels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuel(int id, Fuel fuel)
        {
            if (id != fuel.Id)
            {
                return BadRequest();
            }

            var existingFuel = await _fuelService.GetByIdAsync(id);
            if (existingFuel == null)
            {
                return NotFound();
            }

            await _fuelService.UpdateAsync(fuel);

            return NoContent();
        }

        // POST: api/Fuels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fuel>> PostFuel(Fuel fuel)
        {
            await _fuelService.AddAsync(fuel);

            return CreatedAtAction("GetFuel", new { id = fuel.Id }, fuel);
        }

        // DELETE: api/Fuels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuel(int id)
        {
            var fuel = await _fuelService.GetByIdAsync(id);
            if (fuel == null)
            {
                return NotFound();
            }

            await _fuelService.DeleteAsync(fuel);

            return NoContent();
        }
    }
}
