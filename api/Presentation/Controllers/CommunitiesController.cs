using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

    public CommunitiesController(
        ICommunityService service,
        UserManager<ApplicationUser> userManager) : base(userManager)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<CommunityViewModel>))]
    public async Task<IActionResult> GetEntities([FromQuery] CommunityQueryParams queryParams)
        => await ApiExceptionHandler(async () =>
            Ok(await PaginatedList<CommunityViewModel>.CreateAsync(_service.GetAllVm(queryParams), queryParams)));

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommunityViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEntity(ulong id)
        => await ApiExceptionHandler(async () => Ok(await _service.GetVm(id)));


    [HttpPost("{id}/join")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> JoinCommunity(ulong id)
        => await ApiExceptionHandler(async () =>
        {
            await _service.AddMember(id, GetUserId());
            return NoContent();
        });

    [HttpDelete("{id}/leave")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LaveCommunity(ulong id) => await ApiExceptionHandler(async () =>
    {
        await _service.RemoveMember(id, GetUserId());
        return NoContent();
    });

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CommunityViewModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Create(CreateCommunityModel createModel) => await ApiExceptionHandler(async () =>
    {
        var entityVm = await _service.CreateFromAndGetVm(createModel, GetUserId());

        return CreatedAtAction(
            nameof(GetEntity),
            new {id = entityVm.Id},
            entityVm
        );
    });

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommunityViewModel))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Update(UpdateCommunityModel updateModel, ulong id)
        => await ApiExceptionHandler(async () =>
        {
            var entity = await _service.Get(id);

            if (entity.OwnerId != GetUserId())
            {
                return Forbid();
            }

            await _service.Update(id, updateModel);
            return Ok(await _service.GetVm(entity.Id));
        });

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(ulong id) => await ApiExceptionHandler(async () =>
    {
        var entity = await _service.Get(id);
        if (entity.OwnerId != GetUserId())
        {
            return Forbid();
        }

        await _service.Delete(id);
        return NoContent();
    });
}