using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CourceProject.DTOs;
using CourceProject.Entities;
using CourceProject.Models;
using CourceProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourceProject.Controllers;

public class CommentsController : BaseApiController
{
    private readonly CarsContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CommentsController(CarsContext context, IMapper mapper, UserManager<User> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult> AddComment(CommentDto commentDto)
    {
        var car = await _context.Cars.FindAsync(commentDto.Id);
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var comment = new Comment
        {
            UserName = user.UserName,
            Body = commentDto.Body,
            Car = car
        };

        car!.Comments.Add(comment);

        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Ok();

        return BadRequest(new ProblemDetails {Title = "Failed to add comment."});
        // return Result<CommentDto>.Failure("Failed to add comment");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCommentsList(int id)
    {
        var user = _userManager.FindByNameAsync(User.Identity!.Name);
        
        var comments = await _context.Comments
            .Where(x => x.Car.Id == id)
            .OrderBy(x => x.CreatedAt)
            // .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return Ok(new {comments});
    }
}