using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Comments;
using Sociussion.Application.Common.Interfaces;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Services;

namespace Sociussion.Presentation.Controllers;

[Authorize]
public class CommentsController : ApiController
{
    private readonly ICommentService _service;
    private readonly IMapper _mapper;

    public CommentsController(ICommentService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEntities([FromQuery] QueryParams queryParams)
    {
        var result = await _mapper.ProjectTo<CommentViewModel>(_service.GetAll()).ToListAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
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