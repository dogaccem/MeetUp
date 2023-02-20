using MediatR;
using MeetUp.Application.DomainHandlers.Categories.Commands.CreateCategoryCommand;
using MeetUp.Application.DomainHandlers.Categories.Commands.DeleteCategoryCommand;
using MeetUp.Application.DomainHandlers.Categories.Commands.UpdateCategoryCommand;
using MeetUp.Application.DomainHandlers.Categories.Queries.GetCategoryQueries.GetAllCatogories;
using MeetUp.Application.DomainHandlers.Categories.Queries.GetCategoryQueries.GetCategoryByIdQuery;
using MeetUp.Application.DomainHandlers.Categories.Queries.GetCategoryQueries.GetNonDeletedCatogoriesQueries;
using MeetUp.Application.DomainHandlers.Events.Commands.UpdateEventCommands;
using MeetUp.Persistence.UtilitiesConcrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MeetUp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CategoryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ActionResult<Result>> AddCategoryAsync([FromBody]CreateCategoryCommandRequest requestParameters)
        {
            await _mediatr.Send(requestParameters);

            return Result.Ok("Creating a category has been completed with success");
        }
        [HttpGet("all")]
        public async Task<ActionResult<Result>> GetAllCategoriesAsync([FromQuery]GetAllCategoriesQueryRequest requestParameters)
        {
            var items = await _mediatr.Send(requestParameters);

            return Result.Ok(items,"Getting all categories has been completed with success");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync([FromQuery]GetCategoryByIdQueryRequest requestParameters)
        {
            var item = await _mediatr.Send(requestParameters);

            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody]UpdateCategoryCommandRequest requestParameters)
        {
            await _mediatr.Send(requestParameters);
            return Ok();
        }

        [HttpPut("soft-delete")]
        public async Task<IActionResult> DeleteCategoryAsync([FromBody]DeleteCategoryCommandRequest requestParameters)
        {
            await _mediatr.Send(requestParameters);
            return Ok();
        }

        [HttpGet("non-deleted-all")]
        public async Task<IActionResult> GetAllNonDeletedCategoriesAsync([FromQuery]GetNonDeletedCategoriesQueryRequest requestParameters)
        {
            var items = await _mediatr.Send(requestParameters);

            return Ok(items);
        }
    }
}
