using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;

[ApiController]
public class LoginController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly SignInManager<Account> _signInManager;

    public LoginController(DatabaseContext context, SignInManager<Account> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }
    
    [Route("login")]
    [HttpPost]
    public async Task<ActionResult<ReturnResponse>> Login([FromBody] LoginRequest request)
    {
        // Validate the login credentials against the database
        var resultAccount = _context.Accounts.Where((e) => e.Email == request.emailAddress).FirstOrDefault();
        var result = _signInManager.PasswordSignInAsync(resultAccount, request.wachtwoord, true, false);
        if (result != null)
        {
            // Generate a JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, resultAccount.Email),
                    new Claim(ClaimTypes.NameIdentifier, "1")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key".HashString())),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return new ReturnResponse(200);
        }
        else
        { 
            return new ReturnResponse(404);
        }
    }
}

public class LoginRequest
{
    public string emailAddress{get; set;}
    public string wachtwoord{get; set;}
}

public class ReturnResponse{
    public int code{get; set;}

    public ReturnResponse(int code){
        this.code = code;
    }
}
