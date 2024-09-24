using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Dtos;
using RentACarApi.Models;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _carService.GetAllAsync();
            return Ok(cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carService.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            var existingCar = await _carService.GetByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            await _carService.UpdateAsync(car);

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            await _carService.AddAsync(car);

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            await _carService.DeleteAsync(car);

            return NoContent();
        }

        // GET: api/Car/details
        [HttpGet("details")]
        public async Task<ActionResult<List<CarDetailDto>>> GetAllDetails()
        {
            var details = await _carService.GetAllDetailsAsync();
            return Ok(details);
        }

        // GET: api/Car/details/fuel/{fuelId}
        [HttpGet("details/fuel/{fuelId}")]
        public async Task<ActionResult<List<CarDetailDto>>> GetAllDetailsByFuelId(int fuelId)
        {
            var details = await _carService.GetAllDetailsByFuelIdAsync(fuelId);
            return Ok(details);
        }

        // GET: api/Car/details/color/{colorId}
        [HttpGet("details/color/{colorId}")]
        public async Task<ActionResult<List<CarDetailDto>>> GetAllDetailsByColorId(int colorId)
        {
            var details = await _carService.GetAllDetailsByColorIdAsync(colorId);
            return Ok(details);
        }

        // GET: api/Car/details/price?min={min}&max={max}
        [HttpGet("details/price")]
        public async Task<ActionResult<List<CarDetailDto>>> GetAllDetailsByPriceRange([FromQuery] double min, [FromQuery] double max)
        {
            var details = await _carService.GetAllDetailsByPriceRangeAsync(min, max);
            return Ok(details);
        }

        // GET: api/Car/details/brand?name={brandName}
        [HttpGet("details/brand")]
        public async Task<ActionResult<List<CarDetailDto>>> GetAllDetailsByBrandNameContains([FromQuery] string brandName)
        {
            var details = await _carService.GetAllDetailsByBrandNameContainsAsync(brandName);
            return Ok(details);
        }

        // GET: api/Car/details/model?name={modelName}
        [HttpGet("details/model")]
        public async Task<ActionResult<List<CarDetailDto>>> GetAllDetailsByModelNameContains([FromQuery] string modelName)
        {
            var details = await _carService.GetAllDetailsByModelNameContainsAsync(modelName);
            return Ok(details);
        }

        // GET: api/Car/details/{id}
        [HttpGet("details/{id}")]
        public async Task<ActionResult<CarDetailDto?>> GetDetailById(int id)
        {
            var carDetail = await _carService.GetDetailByIdAsync(id);
            if (carDetail == null)
            {
                return NotFound();
            }
            return Ok(carDetail);
        }

        // GET: api/Car/details/kilometer
        [HttpGet("details/kilometer")]
        public async Task<ActionResult<List<CarDetailDto>>> GetAllDetailsByKilometerRange([FromQuery] int min, [FromQuery] int max)
        {
            var details = await _carService.GetAllDetailsByKilometerRangeAsync(min, max);
            return Ok(details);
        }
    }
}
