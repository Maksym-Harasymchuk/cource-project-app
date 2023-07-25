using CourceProject.Entities;
using CourceProject.Extensions;
using CourceProject.RequestHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CourceProject.DTOs;
using CourceProject.Models;
using CourceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CourceProject.Controllers
{
    public class CarsController : BaseApiController
    {
        private readonly CarsContext _context;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;

        public CarsController(CarsContext context, IMapper mapper, ImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        
        [HttpGet]
        public async Task<ActionResult<PagedList<Car>>> GetCars([FromQuery] VehicleParams vehicleParams)
        {
            var query = _context.Cars
                .Sort(vehicleParams.OrderBy)
                .Search(vehicleParams.SearchTerm)
                .Filter(vehicleParams.Manufacturers)
                .AsQueryable();

            var vehicle = await PagedList<Car>.ToPagedList(query, vehicleParams.PageNumber,
                vehicleParams.PageSize);

            Response.AddPaginationHeader(vehicle.MetaData);

            return vehicle;
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetCarsStatistics()
        {
            var popularity = await _context.Cars
                .GroupBy(vehicle => vehicle.Manufacturer.ToLower())
                .Select(g => new
                {
                    Manufacturer = g.Key,
                    Model = g.Key,
                    Count = g.Count()
                }).ToArrayAsync();

            return Ok(new {popularity});
        }

        [HttpGet("{id}", Name = "GetCar")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var manufacturers = await _context.Cars.Select(i => i.Manufacturer).Distinct().ToArrayAsync();

            return Ok(new {manufacturers});
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar([FromForm] CreateCarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);

            if (carDto.File != null)
            {
                var imageResults = await _imageService.AddImageAsync(carDto.File);

                if (imageResults.Error != null)
                    return BadRequest(new ProblemDetails {Title = imageResults.Error.Message});

                car.PictureUrl = imageResults.SecureUrl.ToString();
                car.PublicId = imageResults.PublicId;
            }

            _context.Cars.Add(car);

            var result = await _context.SaveChangesAsync() > 0;

            if (result)
                return CreatedAtRoute("GetCar", new { car.Id }, car);

            return BadRequest(new ProblemDetails {Title = "Problem creating new car."});
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateCar([FromForm] UpdateCarDto carDto)
        {
            var car = await _context.Cars.FindAsync(carDto.Id);
            if (carDto.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(carDto.File);

                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails {Title = imageResult.Error.Message});

                if (!string.IsNullOrEmpty(car.PublicId))
                    await _imageService.DeleteImageAsync(car.PublicId);

                car.PictureUrl = imageResult.SecureUrl.ToString();
                car.PublicId = imageResult.PublicId;
            }

            if (car == null) return NotFound();

            _mapper.Map(carDto, car);

            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok();

            return BadRequest(new ProblemDetails {Title = "Problem updating car."});
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();

            if (!string.IsNullOrEmpty(car.PublicId))
                await _imageService.DeleteImageAsync(car.PublicId);

            _context.Cars.Remove(car);

            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok();

            return BadRequest(new ProblemDetails {Title = "Problem deleting the car."});
        }
    }
}