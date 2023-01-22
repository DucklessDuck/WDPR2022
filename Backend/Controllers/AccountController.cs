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
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<Account> _usermanager;
        private readonly SignInManager<Account> _signInManager;
        public AccountController(DatabaseContext context, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _context = context;
            _usermanager = userManager;
            _signInManager = signInManager;
        }

        //Get list of accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountList()
        {
            try
            {
                return (await _context.Accounts.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //... Get accountId by emailaddress ..//
        [HttpGet("getAccountByEmail")]
        public async Task<ActionResult<Account>> GetAccountByEmail(string emailAddress)
        {
            var result = await _context.Accounts.Where((e) => e.Email == emailAddress).FirstOrDefaultAsync();
            if (result == null)
                return NotFound();

            return result;
        }

        //... Create Account ...//
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequestData request)
        {
            var user = new Account { UserName = request.username, Email = request.emailAddress, PasswordHash = request.password };
            var result = await _usermanager.CreateAsync(user);
            return result.Succeeded ? new BadRequestObjectResult(result) : StatusCode(201);
        }


        public class CreateAccountRequestData
        {
            public string username { get; set; }
            public string emailAddress { get; set; }
            public string password { get; set; }
        }
    }
}
