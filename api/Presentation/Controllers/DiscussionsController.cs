using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Application.Common.Models;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Discussions;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;

namespace Sociussion.Presentation.Controllers;

[Authorize]
public class DiscussionsController : ApiController
{
    private readonly IDiscussionService _service;

    public DiscussionsController(
        IDiscussionService service,
        UserManager<ApplicationUser> userManager) : base(userManager)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Create(CreateDiscussionModel createModel)
        => await ApiExceptionHandler(async () =>
        {
            var entityVm = await _service.CreateFromAndGetVm(createModel, GetUserId());

            return CreatedAtAction(
                nameof(GetEntity),
                new {id = entityVm.Id},
                entityVm
            );
        });

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<DiscussionViewModel>))]
    public async Task<IActionResult> GetEntities([FromQuery] DiscussionQueryParams queryParams)
        => await ApiExceptionHandler(async () =>
            Ok(await PaginatedList.CreateAndOrderAsync(_service.GetAllVm(queryParams), queryParams)));

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DiscussionViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEntity(int id)
        => await ApiExceptionHandler(async () => Ok(await _service.GetVm(id)));

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DiscussionViewModel))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Update(UpdateDiscussionModel updateModel, int id)
        => await ApiExceptionHandler(async () =>
        {
            var entity = await _service.Get(id);

            if (entity.AuthorId != GetUserId())
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
    public async Task<IActionResult> Delete(int id)
        => await ApiExceptionHandler(async () =>
        {
            var entity = await _service.Get(id);

            if (entity.AuthorId != GetUserId())
            {
                return Forbid();
            }

            await _service.Delete(id);
            return NoContent();
        });
}