using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Models;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Discussions;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;

namespace Sociussion.Presentation.Controllers;

[Authorize]
public class DiscussionsController : ApiController
{
    private readonly ICommunityService _communityService;
    private readonly IDiscussionService _service;
    private readonly IMapper _mapper;

    public DiscussionsController(
        ICommunityService communityService,
        IDiscussionService service,
        IMapper mapper,
        UserManager<ApplicationUser> userManager) : base(userManager)
    {
        _communityService = communityService;
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Create(CreateDiscussionModel createModel)
    {
        if (!(await _communityService.Get(createModel.CommunityId).AnyAsync()))
        {
            return ApiValidationError(nameof(createModel.CommunityId), "Given community doesn't exist.");
        }

        try
        {
            var entity = await _service.CreateFrom(createModel, GetUserId());

            return CreatedAtAction(
                nameof(GetEntity),
                new {id = entity.Id},
                _mapper.Map<DiscussionViewModel>(entity)
            );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<DiscussionViewModel>))]
    public async Task<IActionResult> GetEntities([FromQuery] DiscussionQueryParams queryParams)
    {
        var query = _mapper.ProjectTo<DiscussionViewModel>(_service.GetAll(queryParams));
        var result = await PaginatedList<DiscussionViewModel>.CreateAsync(query, queryParams);

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DiscussionViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEntity(ulong id)
    {
        var entity = await _mapper.ProjectTo<DiscussionViewModel>(_service.Get(id)).FirstOrDefaultAsync();

        if (entity is null)
        {
            return NotFound();
        }

        return Ok(entity);
    }
}