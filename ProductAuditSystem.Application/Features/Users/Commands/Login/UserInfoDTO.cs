﻿
namespace ProductAuditSystem.Application.Features.Users.Commands.Login;

public class UserInfoDTO
{
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string>? Roles { get; set; }
    public string Token { get; set; } = string.Empty;
}
