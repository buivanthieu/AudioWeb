using AudioWeb.Core.Application.Commands.Channels;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Application.Queries.Channels;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChannelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseListResponse<ChannelListDto>>> GetAllChannels()
        {
            try
            {
                var query = new GetAllChannelsQuery();
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<ChannelListDto>(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<BaseResponse<ChannelDto>>> GetChannelById(int id)
        {
            try
            {
                var query = new GetChannelByIdQuery(id);
                var result = await _mediator.Send(query);
                return this.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<ChannelDto>(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<ChannelDto>>> CreateChannel([FromBody] CreateChannelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Channel created successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<ChannelDto>(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteChannel([FromQuery] int id)
        {
            try
            {
                var command = new DeleteChannelCommand(id);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Channel deleted successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResponse<ChannelDto>>> UpdateChannel([FromBody] UpdateChannelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Channel updated successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<ChannelDto>(ex.Message);
            }
        }

    }
}
