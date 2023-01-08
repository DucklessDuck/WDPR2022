using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<ReturnResponse>> Login([FromBody] LoginRequest request)
    {
        // Validate the login credentials against the database

        if (request.gebruikersnaam == "gebruikersnaam" && request.wachtwoord == "wachtwoord")
        {
            // Generate a JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, request.gebruikersnaam),
                    new Claim(ClaimTypes.NameIdentifier, "1")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key")),
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
    public string gebruikersnaam{get; set;}
    public string wachtwoord{get; set;}
}

public class ReturnResponse{
    public int code{get; set;}

    public ReturnResponse(int code){
        this.code = code;
    }
}
