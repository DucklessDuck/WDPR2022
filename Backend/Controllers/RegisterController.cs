using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly IConfiguration _config;
        public RegisterController(UserManager<Account> userManager, SignInManager<Account> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = new Account { Email = request.emailAddress };
            var result = await _userManager.CreateAsync(user, request.wachtwoord);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }

    }

    public class RegisterRequest
    {
        public string emailAddress { get; set; }
        public string wachtwoord { get; set; }
    }
}