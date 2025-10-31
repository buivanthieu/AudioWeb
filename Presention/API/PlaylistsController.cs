using AudioWeb.Core.Application.Commands.Playlists;
using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Application.Queries.Playlists;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlaylistsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseListResponse<PlaylistDto>>> GetAllPlaylists()
        {
            try
            {
                var query = new GetAllPlaylistsQuery();
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<PlaylistDto>(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<BaseResponse<PlaylistDto>>> GetPlaylistById([FromBody] int id)
        {
            try
            {
                var query = new GetPlaylistByIdQuery(id);
                var result = await _mediator.Send(query);
                return this.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<PlaylistDto>(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<PlaylistDto>>> CreatePlaylist([FromBody] CreatePlaylistCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Playlist created successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<PlaylistDto>(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeletePlaylist([FromQuery] int id)
        {
            try
            {
                var command = new DeletePlaylistCommand(id);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Playlist deleted successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResponse<PlaylistDto>>> UpdatePlaylist([FromBody] UpdatePlaylistCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Playlist updated successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<PlaylistDto>(ex.Message);
            }
        }

        [HttpGet("get-playlists-channel")]
        public async Task<ActionResult<BaseListResponse<PlaylistDto>>> GetPlaylistsByChannelId([FromQuery] int channelId)
        {
            try
            {
                var query = new GetAllPlaylistsByChannelIdQuery(channelId);
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<PlaylistDto>(ex.Message);
            }
        }

        [HttpGet("get-track-status-in-playlist")]
        public async Task<ActionResult<BaseListResponse<PlaylistWithTrackStatusDto>>> GetPlaylistsWithTrack([FromQuery] int channelId)
        {
            try
            {
                var query = new GetPlaylistsWithTrackQuery(channelId);
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<PlaylistWithTrackStatusDto>(ex.Message);
            }
        }

        [HttpPost("add-track-to-playlist")]
        public async Task<ActionResult<BaseResponse<bool>>> AddTrackToPlaylist([FromBody] AddTrackToPlaylistCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Track added to playlist successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

        [HttpDelete("remove-track-from-playlist")]
        public async Task<ActionResult<BaseResponse<bool>>> RemoveTrackFromPlaylist([FromQuery] RemoveTrackFromPlaylistCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Track removed from playlist successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }
    }
}
