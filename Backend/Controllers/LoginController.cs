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
    [Route("Login")]
    public ActionResult Login([FromBody] LoginRequest request)
    {
        // Validate the login credentials against the database

        if (request.Gebruikersnaam == "gebruikersnaam" && request.Wachtwoord == "wachtwoord")
        {
            // Generate a JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, request.Gebruikersnaam),
                    new Claim(ClaimTypes.NameIdentifier, "1")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key")),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the JWT in the response
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }
        else
        { 
            
        }
    }
}

public class LoginRequest
{
    public string Gebruikersnaam{get; set;}
    public string Wachtwoord{get; set;}
}

