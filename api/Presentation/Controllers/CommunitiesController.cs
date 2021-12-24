﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Exceptions;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<CommunityViewModel>))]
    public async Task<IActionResult> GetEntities([FromQuery] CommunityQueryParams queryParams)
    {
        var query = _mapper.ProjectTo<CommunityViewModel>(_service.GetAll(queryParams));
        var result = await PaginatedList<CommunityViewModel>.CreateAsync(query, queryParams);

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommunityViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> JoinCommunity(ulong id)
    {
        try
        {
            if (await _service.AddMember(id, GetUserId()))
            {
                return NoContent();
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NotFound();
    }

    [HttpDelete("{id}/leave")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LaveCommunity(ulong id)
    {
        try
        {
            if (await _service.RemoveMember(id, GetUserId()))
            {
                return NoContent();
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CommunityViewModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Create(CreateCommunityModel createModel)
    {
        try
        {
            var entityVm = await _service.CreateFromAndGetVm(createModel, GetUserId());

            return CreatedAtAction(
                nameof(GetEntity),
                new {id = entityVm.Id},
                entityVm
            );
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommunityViewModel))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Update(UpdateCommunityModel updateModel, ulong id)
    {
        var entity = await _service.Get(id).FirstOrDefaultAsync();

        if (entity is null)
        {
            return NotFound();
        }

        if (entity.OwnerId != GetUserId())
        {
            return Forbid();
        }

        try
        {
            await _service.Update(id, updateModel);
            return Ok(await _service.GetVm(entity.Id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(ulong id)
    {
        var entity = await _service.Get(id).FirstOrDefaultAsync();

        if (entity is null)
        {
            return NotFound();
        }

        if (entity.OwnerId != GetUserId())
        {
            return Forbid();
        }

        try
        {
            await _service.Delete(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}