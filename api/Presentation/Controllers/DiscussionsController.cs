﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Interfaces;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Discussions;
using Sociussion.Application.Services;

namespace Sociussion.Presentation.Controllers;

[Authorize]
public class DiscussionsController : ApiController
{
    private readonly ICommunityService _communityService;
    private readonly IDiscussionService _service;
    private readonly IMapper _mapper;

    public DiscussionsController(ICommunityService communityService, IDiscussionService service, IMapper mapper)
    {
        _communityService = communityService;
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDiscussionModel createModel)
    {
        if (!(await _communityService.Get(createModel.CommunityId).AnyAsync()))
        {
            return BadApiRequest(nameof(createModel.CommunityId), "Given community doesn't exist.");
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
    public async Task<IActionResult> GetEntities([FromQuery] QueryParams queryParams)
    {
        var result = await _mapper.ProjectTo<DiscussionViewModel>(_service.GetAll()).ToListAsync();
        
        return Ok(result);
    }

    [HttpGet("{id}")]
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