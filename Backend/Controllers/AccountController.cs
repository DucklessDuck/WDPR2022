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
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Controllers
{
    [Authorize]
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

        //... Create Account ...//
        [HttpPost]
        public async Task<ActionResult<Account>> PostUser(Account account)
        {
            if (_context.Accounts == null)
            {
                return Problem("No users found. ");
            }
            _context.Accounts.Add(account);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (getUser(account.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = account.Id }, account);
        }

        //... Edit Account ...//
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            // _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!getUser(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var user = await _context.Accounts.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool getUser(string id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public class CreateAccountRequestData
        {
            public string username { get; set; }
            public string emailAddress { get; set; }
            public string password { get; set; }
        }
    }
}
