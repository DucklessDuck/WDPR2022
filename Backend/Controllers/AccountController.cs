using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{

    public AccountController()
    {
        
    }

    [HttpPost]
    [Route("create")]
    public ActionResult CreateAccount([FromBody] CreateAccountRequestData request)
    {
        // Create the account and return a response
        // ...

        // Validate the request data and create the account in the database
        var created = CreateAccountInDatabase(request.Username, request.EmailAddress, request.Password);
        if (request.Username == null || request.EmailAddress == null || request.Password == null)
        {
            return BadRequest("Leeg veld!");
        }
    }
}

public class CreateAccountRequestData
{
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}

public class Response
{
    public int code { get; set; }
    public string message { get; set; }
}
