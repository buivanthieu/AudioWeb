using AudioWeb.Core.Application.DTOs.Auths;
using MediatR;


namespace AudioWeb.Core.Application.Commands.Auths
{
    public record RegisterCommand(RegisterDto RegisterDto) : IRequest<AuthResponseDto>
    {
    }
}
