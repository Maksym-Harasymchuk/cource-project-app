using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourceProject.DTOs;
using CourceProject.Entities;
using CourceProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourceProject.Controllers;

public class FavouritesController : BaseApiController
{
    private readonly CarsContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public FavouritesController(CarsContext context, IMapper mapper, UserManager<User> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddToFavourites(int id)
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name);
        var car = await _context.Cars.FindAsync(id);
        var favouriteCheck = await _context.FavouritesCars.Where(c => c.CarId == id && c.UserId == user.Id).FirstOrDefaultAsync();
        var favourite = new Favourite
        {
            Manufacturer = car?.Manufacturer,
            //Car = car,
            CarId = car?.Id,
            CarModel = car?.Model,
            UserId = user?.Id
        };

        //if (favouriteCheck == null && car != null)
        if (favouriteCheck?.UserId == user?.Id && favouriteCheck?.CarId == id)
            return Ok();
        _context.FavouritesCars.Add(favourite);
        // user.Favourites.Add(favourite);

        var result = await _context.SaveChangesAsync() > 0;

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveFavourite(int id)
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name);
        var car = _context.FavouritesCars
            .Where(u => u.UserId == user.Id && u.Car.Id == id)
            .Select(c => c).FirstOrDefault();

        if (car == null) return NotFound();

        _context.FavouritesCars.Remove(car);

        var result = await _context.SaveChangesAsync() > 0;

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> SearchFavourite(int id)
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name);
        var car = _context.FavouritesCars
            .Where(u => u.UserId == user.Id && u.Car.Id == id)
            .Select(c => c.Id);

        return Ok(car);
    }

    [HttpGet("statistics")]
    public async Task<IActionResult> GetMostPopularModels()
    {
        var duplicates = await _context.FavouritesCars
            .GroupBy(v => v.Manufacturer.ToLower() + " " + v.CarModel.ToLower())
            .Where(x => x.Count() > 1 )
            .Select(g => new
            {
               Model = g.Key,
               Id = g.Key,
               Count = g.Count()
            }).ToArrayAsync();

        var mostPopular = duplicates.OrderByDescending(x => x.Count);


        return Ok(new {mostPopular});
    }

    [Authorize]
    [HttpGet("byUser")]
    public async Task<IActionResult> GeFavouritesByUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name);

        var favourites = await _context.FavouritesCars
            .Where(u => u.UserId == user.Id)
            .ToArrayAsync();
        // .GroupBy(u => u.UserId)
        // .Where(u => u.UserId == user.Id);
        // .Select(g => new
        // {
        //     Model = g.Key,
        //     Id = g.Key,
        //     Count = g.Count()
        // }).ToArrayAsync();


        return Ok(new {favourites});
    }
}