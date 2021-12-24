using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

    public CommentsController(
        ICommentService service,
        UserManager<ApplicationUser> userManager) : base(userManager)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<CommentViewModel>))]
    public async Task<IActionResult> GetEntities([FromQuery] CommentQueryParams queryParams)
        => await ApiExceptionHandler(async () =>
            Ok(await PaginatedList<CommentViewModel>.CreateAsync(_service.GetAllVm(queryParams), queryParams)));


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEntity(ulong id)
        => await ApiExceptionHandler(async () => Ok(await _service.GetVm(id)));


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CommentViewModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Create(CreateCommentModel createModel) => await ApiExceptionHandler(async () =>
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentViewModel))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Update(UpdateCommentModel updateModel, ulong id) => await ApiExceptionHandler(
        async () =>
        {
            var entity = await _service.Get(id);

            if (entity.AuthorId != GetUserId())
            {
                return Forbid();
            }

            await _service.Update(id, updateModel);
            return Ok(await _service.GetVm(entity.Id));
        }
    );


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(ulong id) => await ApiExceptionHandler(async () =>
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