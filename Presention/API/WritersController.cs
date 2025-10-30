using AudioWeb.Core.Application.Commands.Writers;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Application.Queries.Writers;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WritersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseListResponse<WriterListDto>>> GetAllWriters()
        {
            try
            {
                var query = new GetAllWritersQuery();
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<WriterListDto>(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<BaseResponse<WriterDto>>> GetWriterById(int id)
        {
            try
            {
                var query = new GetWriterByIdQuery(id);
                var result = await _mediator.Send(query);
                return this.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<WriterDto>(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<WriterDto>>> CreateWriter([FromBody] CreateWriterCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Writer created successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<WriterDto>(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteWriter([FromQuery] int id)
        {
            try
            {
                var command = new DeleteWriterCommand(id);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Writer deleted successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

        //[HttpPut("update")]
        //public async Task<ActionResult<BaseResponse<WriterDto>>> UpdateWriter([FromBody] UpdateWriterCommand command)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(command);
        //        return this.SuccessResponse(result, "Writer updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.BadRequestResponse<WriterDto>(ex.Message);
        //    }
        //}
    }
}
