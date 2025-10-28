using AudioWeb.Core.Application.Commands.Tags;
using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.Queries.Tags;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseListResponse<TagDto>>> GetAllTags()
        {
            try
            {
                var query = new GetAllTagsQuery();
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<TagDto>(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<BaseResponse<TagDto>>> GetTagById(int id)
        {
            try
            {
                var query = new GetTagByIdQuery(id);
                var result = await _mediator.Send(query);
                return this.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<TagDto>(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<TagDto>>> CreateTag([FromBody] CreateTagCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Tag created successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<TagDto>(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteTag([FromQuery] int id)
        {
            try
            {
                var command = new DeleteTagCommand(id);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Tag deleted successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

            //[HttpPut("update")]
            //public async Task<ActionResult<BaseResponse<TagDto>>> UpdateTag([FromBody] UpdateTagCommand command)
            //{
            //    try
            //    {
            //        var result = await _mediator.Send(command);
            //        return this.SuccessResponse(result, "Tag updated successfully.");
            //    }
            //    catch (Exception ex)
            //    {
            //        return this.BadRequestResponse<TagDto>(ex.Message);
            //    }
            //}
    }
}
