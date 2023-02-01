using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;

[ApiController]
public class LoginController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly SignInManager<Account> _signInManager;
    private readonly UserManager<Account> _userManager;
    public IConfiguration _configuration;

    public LoginController(DatabaseContext context, SignInManager<Account> signInManager, IConfiguration config)
    {
        _context = context;
        _signInManager = signInManager;
        _configuration = config;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.emailAddress);
        if (user == null)
        {
            return Unauthorized();
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.wachtwoord, false);
        if (!result.Succeeded)
        {
            return Unauthorized();
        }
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id)
            };
        foreach (var role in roles)
        {
            claims.Add(new Claim("roles", role));
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:SigningKey")));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration.GetValue<string>("JWT:Issuer"),
            _configuration.GetValue<string>("JWT:Issuer"),
            claims,
            expires: DateTime.Now.AddDays(10),
            signingCredentials: creds);
        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

}

public class LoginRequest
{
    public string emailAddress { get; set; }
    public string wachtwoord { get; set; }
}

public class ReturnResponse
{
    public int code { get; set; }

    public ReturnResponse(int code)
    {
        this.code = code;
    }
}

