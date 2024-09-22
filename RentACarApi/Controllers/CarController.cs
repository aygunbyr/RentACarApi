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
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarService _carService;

        public CarController(ApplicationDbContext context, ICarService carService)
        {
            _context = context;
            _carService = carService;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Car/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Car
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }

        // GET: api/Car/details
        [HttpGet("details")]
        public ActionResult<List<CarDetailDto>> GetAllDetails()
        {
            return Ok(_carService.GetAllDetails());
        }

        // GET: api/Car/details/fuel/{fuelId}
        [HttpGet("details/fuel/{fuelId}")]
        public ActionResult<List<CarDetailDto>> GetAllDetailsByFuelId(int fuelId)
        {
            return Ok(_carService.GetAllDetailsByFuelId(fuelId));
        }

        // GET: api/Car/details/color/{colorId}
        [HttpGet("details/color/{colorId}")]
        public ActionResult<List<CarDetailDto>> GetAllDetailsByColorId(int colorId)
        {
            return Ok(_carService.GetAllDetailsByColorId(colorId));
        }

        // GET: api/Car/details/price?min={min}&max={max}
        [HttpGet("details/price")]
        public ActionResult<List<CarDetailDto>> GetAllDetailsByPriceRange([FromQuery] double min, [FromQuery] double max)
        {
            return Ok(_carService.GetAllDetailsByPriceRange(min, max));
        }

        // GET: api/Car/details/brand?name={brandName}
        [HttpGet("details/brand")]
        public ActionResult<List<CarDetailDto>> GetAllDetailsByBrandNameContains([FromQuery] string brandName)
        {
            return Ok(_carService.GetAllDetailsByBrandNameContains(brandName));
        }

        // GET: api/Car/details/model?name={modelName}
        [HttpGet("details/model")]
        public ActionResult<List<CarDetailDto>> GetAllDetailsByModelNameContains([FromQuery] string modelName)
        {
            return Ok(_carService.GetAllDetailsByModelNameContains(modelName));
        }

        // GET: api/Car/details/{id}
        [HttpGet("details/{id}")]
        public ActionResult<CarDetailDto?> GetDetailById(int id)
        {
            var carDetail = _carService.GetDetailById(id);
            if (carDetail == null)
            {
                return NotFound();
            }
            return Ok(carDetail);
        }

        // GET: api/Car/details/kilometer
        [HttpGet("details/kilometer")]
        public ActionResult<List<CarDetailDto>> GetAllDetailsByKilometerRange([FromQuery] int min, [FromQuery] int max)
        {
            return Ok(_carService.GetAllDetailsByKilometerRange(min, max));
        }
    }
}
