using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Discussion;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;

namespace Sociussion.Controllers
{
    [Authorize]
    public class
        DiscussionsController : RepositoryApiController<IDiscussionRepository, Discussion, ulong, DiscussionParams>
    {
        public DiscussionsController(IDiscussionRepository repository) : base(repository)
        {
        }
    }
    
    // public class DiscussionsController : GenericApiController<Discussion, ulong>
    // {
    //     public DiscussionsController(IUnitOfWork unitOfWork)
    //         : base(unitOfWork.DiscussionRepository)
    //     {
    //     }
    //
    //     [HttpPost]
    //     public async Task<IActionResult> CreateDiscussion(CreateDiscussionModel createModel)
    //     {
    //         var model = new Discussion() {Title = createModel.Title};
    //
    //         try
    //         {
    //             await Repository.Add(model);
    //
    //             return CreatedAtAction(nameof(GetEntity), new {id = model.Id}, model);
    //         }
    //         catch (Exception e)
    //         {
    //             return BadRequest(e.Message);
    //         }
    //     }
    // }
}
