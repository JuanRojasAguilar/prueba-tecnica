using System;
using api.Dtos.Admin;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class AccountController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(ITokenService tokenService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest("Check your credentials");

        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user == null) return BadRequest("Check your credentials");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized("Check your credentials");

        var token = _tokenService.CreateToken(user);

        SaveJwtCookie(token);

        return Ok(new AdminDto
        {
            UserName = user.UserName,
            Email = user.Email,
            Token = token
        });
    }

    private void SaveJwtCookie(string token)
    {
        var options = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(7)
        };

        Response.Cookies.Append("jwt", token, options);
    }
}
