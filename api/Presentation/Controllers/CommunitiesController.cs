using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Models;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Communities;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;

namespace Sociussion.Presentation.Controllers;

[Authorize]
public class CommunitiesController : ApiController
{
    private readonly ICommunityService _service;
    private readonly IMapper _mapper;

    public CommunitiesController(
        ICommunityService service,
        IMapper mapper,
        UserManager<ApplicationUser> userManager) : base(userManager)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEntities([FromQuery] QueryParams queryParams)
    {
        var query = _mapper.ProjectTo<CommunityViewModel>(_service.GetAll());
        var result = await PaginatedList<CommunityViewModel>.CreateAsync(query, queryParams);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEntity(ulong id)
    {
        var result = await _mapper.ProjectTo<CommunityViewModel>(_service.Get(id)).FirstOrDefaultAsync();

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("{id}/join")]
    public async Task<IActionResult> JoinCommunity(ulong id)
    {
        try
        {
            if (await _service.AddMember(id, GetUserId()))
            {
                return Ok();
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NotFound();
    }

    [HttpDelete("{id}/leave")]
    public async Task<IActionResult> LaveCommunity(ulong id)
    {
        try
        {
            if (await _service.RemoveMember(id, GetUserId()))
            {
                return Ok();
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommunityModel createModel)
    {
        try
        {
            var entity = await _service.CreateFrom(createModel, GetUserId());

            return CreatedAtAction(
                nameof(GetEntity),
                new {id = entity.Id},
                _mapper.Map<CommunityViewModel>(entity)
            );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}