
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using SchoolManagementSystem.Application.Authenticate.Interfaces;
using SchoolManagementSystem.Application.Authenticate.Models;
using SchoolManagementSystem.API.Dtos;

namespace SchoolManagementSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticateService _services;

    public AuthenticateController(IAuthenticateService services)
    {
        _services = services;    
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var resp = await _services.Login(loginDto.Username, loginDto.Password);

        if (resp.Status == "Successful")
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(resp.Result),
                expiration = resp.Result.ValidTo
            });

        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var resp = await _services.Register(registerDto.Username, registerDto.Email, registerDto.Password);

        if (resp.Status == "Error")
            return StatusCode(StatusCodes.Status500InternalServerError, resp);

        return Ok(resp);
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
    {
        var resp = await _services.RegisterAdmin(registerDto.Username, registerDto.Email, registerDto.Password);

        if (resp.Status == "Error")
            return StatusCode(StatusCodes.Status500InternalServerError, resp);

        return Ok(resp);
    }

    [Authorize]
    [HttpGet("loggedIn")]
    public IActionResult LoggedIn()
    {
        return Ok();
    }
}