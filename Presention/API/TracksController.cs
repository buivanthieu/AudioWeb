using AudioWeb.Core.Application.Commands.Tracks;
using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Queries.Tracks;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TracksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseListResponse<TrackDto>>> GetAllTracks()
        {
            try
            {
                var query = new GetAllTracksQuery();
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<TrackDto>(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<BaseResponse<TrackDto>>> GetTrackById(int id)
        {
            try
            {
                var query = new GetTrackByIdQuery(id);
                var result = await _mediator.Send(query);
                return this.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<TrackDto>(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<TrackDto>>> CreateTrack([FromBody] CreateTrackCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Track created successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<TrackDto>(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteTrack([FromQuery] int id)
        {
            try
            {
                var command = new DeleteTrackCommand(id);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Track deleted successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResponse<TrackDto>>> UpdateTrack([FromBody] UpdateTrackCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Track updated successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<TrackDto>(ex.Message);
            }
        }

        [HttpGet("get-tracks-channel")]
        public async Task<ActionResult<BaseListResponse<TrackDto>>> GetTracksUploadByChannelId([FromQuery] int channelId)
        {
            try
            {
                var query = new GetAllTracksUploadByChannelIdQuery(channelId);
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<TrackDto>(ex.Message);
            }
        }
    }
}
