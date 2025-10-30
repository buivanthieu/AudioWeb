using AudioWeb.Core.Application.Commands.OriginalStories;
using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Application.Queries.OriginalStories;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginalStoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OriginalStoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseListResponse<OriginalStoryListDto>>> GetAllOriginalStories()
        {
            try
            {
                var query = new GetAllOriginalStoriesQuery();
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<OriginalStoryListDto>(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<BaseResponse<OriginalStoryDto>>> GetOriginalStoryById(int id)
        {
            try
            {
                var query = new GetOriginalStoryByIdQuery(id);
                var result = await _mediator.Send(query);
                return this.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<OriginalStoryDto>(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<OriginalStoryDto>>> CreateOriginalStory([FromBody] CreateOriginalStoryCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "OriginalStory created successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<OriginalStoryDto>(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteOriginalStory([FromQuery] int id)
        {
            try
            {
                var command = new DeleteOriginalStoryCommand(id);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "OriginalStory deleted successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

        //[HttpPut("update")]
        //public async Task<ActionResult<BaseResponse<OriginalStoryDto>>> UpdateOriginalStory([FromBody] UpdateOriginalStoryCommand command)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(command);
        //        return this.SuccessResponse(result, "OriginalStory updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.BadRequestResponse<OriginalStoryDto>(ex.Message);
        //    }
        //}
    }
}
