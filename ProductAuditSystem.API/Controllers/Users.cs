using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Features.Users.Commands.CreateUser;
using ProductAuditSystem.Application.Features.Users.Commands.UpdateUser;
using ProductAuditSystem.Application.Features.Users.Commands.DeleteUser;
using ProductAuditSystem.Application.Features.Users.Commands.Login;
using ProductAuditSystem.Application.Features.Users.Queries.GetUserQuery;
using ProductAuditSystem.Application.Features.Users.Queries.GetUsersQuery;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Application.Contracts.Infrastructure.ActiveDirectory;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.API.Controllers;

#nullable disable

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
public class Users : BaseController
{
    private readonly IConfiguration _configuration;
    private readonly IActiveDirectory _activeDirectory;

    public Users(IMediator mediator, IConfiguration configuration, IActiveDirectory activeDirectory) : base(mediator)
    {
        _configuration = configuration;
        _activeDirectory = activeDirectory;
    }
    [AllowAnonymous]
    [HttpPost("/api/Login")]
    public async Task<ActionResult<UserInfoDTO>> Login(CommandUserLogin login)
    {
        var usuario = await _mediator.Send(login);
        usuario.Token = GenerarToken(usuario);
        return Ok(usuario);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDTO>>> Get()
    {
        var usuarios = await _mediator.Send(new GetUsersQuery());
        return Ok(usuarios);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<UserDTO>> Get(string username)
    {
        var rol = await _mediator.Send(new GetUserQuery(username));
        return Ok(rol);
    }

    [HttpGet("searchActive/{username}")]
    public ActionResult<WindowsUser> GetUserAD(string username)
    {
        var usuarioAD = _activeDirectory.searchUser(username);
        return Ok(usuarioAD);
    }

    [HttpPut]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdateUser commandUpdate)
    {
        var response = await _mediator.Send(commandUpdate);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateUser commandCreateUser)
    {
        var response = await _mediator.Send(commandCreateUser);
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int Id)
    {
        var response = await _mediator.Send(new CommandDeleteUser(Id));
        return Ok(response);
    }

    private string GenerarToken(UserInfoDTO user)
    {
        List<Claim> claims = new() { new Claim(ClaimTypes.Name, user.Username), new Claim(ClaimTypes.Role, user.Roles[0]) };
        var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims.ToArray(),
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:DurationInHours"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials
                (
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256
                )
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
