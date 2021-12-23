using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Comments;
using Sociussion.Application.Common.Models;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;

namespace Sociussion.Presentation.Controllers;

[Authorize]
public class CommentsController : ApiController
{
    private readonly ICommentService _service;
    private readonly IMapper _mapper;

    public CommentsController(
        ICommentService service,
        IMapper mapper,
        UserManager<ApplicationUser> userManager) : base(userManager)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<CommentViewModel>))]
    public async Task<IActionResult> GetEntities([FromQuery] CommentQueryParams queryParams)
    {
        var query = _mapper.ProjectTo<CommentViewModel>(_service.GetAll(queryParams));
        var result = await PaginatedList<CommentViewModel>.CreateAsync(query, queryParams);

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEntity(ulong id)
    {
        var result = await _mapper.ProjectTo<CommentViewModel>(_service.Get(id)).FirstOrDefaultAsync();

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Create(CreateCommentModel createModel)
    {
        try
        {
            var entity = await _service.CreateFrom(createModel, GetUserId());

            return CreatedAtAction(
                nameof(GetEntity),
                new {id = entity.Id},
                _mapper.Map<CommentViewModel>(entity)
            );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}