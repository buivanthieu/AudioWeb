using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Commands.Auths;
using AudioWeb.Core.Application.DTOs.Auths;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Application.DTOs.Channels;

namespace AudioWeb.Core.Application.Handlers.Auths
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;
        public RegisterHandler(IAuthRepository authRepository, IUserRepository userRepository,
            IChannelRepository channelRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken = default)
        {
            var existingUser = await _authRepository.GetUserByEmailAsync(request.RegisterDto.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var passwordHash = _authRepository.HashPassword(request.RegisterDto.Password);
            var newUser = _mapper.Map<User>(request.RegisterDto);
            var createdUser = await _userRepository.AddAsync(newUser);

            var newChannelDto = new CreateChannelDto
            {
                Name = request.RegisterDto.ChannelName,
                UserId = newUser.Id
            };

            var newChannel = _mapper.Map<Channel>(newChannelDto);
            var createdChannel = await _channelRepository.AddAsync(newChannel);

            var token = _authRepository.CreateToken(createdUser, createdChannel.Id);

            return new AuthResponseDto
            {
                Token = token,
                UserId = createdUser.Id,
                Email = createdUser.Email,
                Role = createdUser.Role,
                ChannelId = createdChannel.Id
            };
        }
    }
}
