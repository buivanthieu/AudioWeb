using AudioWeb.Core.Application.Commands.Auths;
using AudioWeb.Core.Application.DTOs.Auths;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<BaseResponse<AuthResponseDto>>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var command = new RegisterCommand(registerDto);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "User registered successfully.");
            }
            catch (ArgumentException ex)
            {
                return this.BadRequestResponse<AuthResponseDto>(ex.Message);
            }
            catch (Exception ex)
            {
                return this.InternalServerErrorResponse<AuthResponseDto>(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<AuthResponseDto>>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var command = new LoginCommand(loginDto);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Login successful.");
            }
            catch (ArgumentException ex)
            {
                return this.BadRequestResponse<AuthResponseDto>(ex.Message);
            }
            catch (Exception ex)
            {
                return this.InternalServerErrorResponse<AuthResponseDto>(ex.Message);
            }
        }
    }
}
