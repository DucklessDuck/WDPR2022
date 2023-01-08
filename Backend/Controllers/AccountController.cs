using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AccountController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAccount([FromBody] CreateAccountRequestData request)
        {
            // Validate the request data and create the account in the database
            if (request.username == null || request.emailAddress == null || request.password == null)
            {
                return BadRequest("Leeg veld!");
            }
            var accountId = await _context.Accounts.ToListAsync();

            Account account = new Account(request.username, request.emailAddress, request.password, "gebruiker", accountId.Count() +1);
            _context.Accounts.Add(account);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

public class CreateAccountRequestData
{
    public string username { get; set; }
    public string emailAddress { get; set; }
    public string password { get; set; }
}

public class Response
{
    public int code { get; set; }
    public string message { get; set; }
}
