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
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColors()
        {
            var colors = await _colorService.GetAllAsync();
            return Ok(colors);
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
            var color = await _colorService.GetByIdAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }

        // PUT: api/Colors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color)
        {
            if (id != color.Id)
            {
                return BadRequest();
            }

            var existingColor = await _colorService.GetByIdAsync(id);
            if (existingColor == null)
            {
                return NotFound();
            }

            Color puttedColor = await _colorService.UpdateAsync(color);

            return Ok(puttedColor);
        }

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
            Color addedColor = await _colorService.AddAsync(color);

            return CreatedAtAction("GetColor", new { id = color.Id }, addedColor);
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var color = await _colorService.GetByIdAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            Color deletedColor = await _colorService.DeleteAsync(color);

            return Ok(deletedColor);
        }
    }
}
