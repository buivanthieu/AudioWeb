﻿namespace AudioWeb.Core.Application.DTOs.Auths
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int ChannelId { get; set; }
    }
}
