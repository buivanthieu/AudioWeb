using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Commands.Auths;
using AudioWeb.Core.Application.DTOs.Auths;
using AudioWeb.Core.Domain.Interfaces;

namespace AudioWeb.Core.Application.Handlers.Auths
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthResponseDto>
    {
        private readonly IAuthRepository _authRepository;
        public LoginHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken = default)
        {
            var user = await _authRepository.GetUserByEmailAsync(request.LoginDto.Email);
            if (user == null || user.Channel == null)
            {
                throw new ArgumentException("email not exist");
            }

            var isPasswordValid = _authRepository.VerifyPassword(request.LoginDto.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new ArgumentException("invalid password");
            }

            var token = _authRepository.CreateToken(user, user.Channel.Id);
            
            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role,
                ChannelId = user.Channel.Id
            };
        }
    }
}
