
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class FakePayController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FakePayController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("fakepay/success")]
        public async Task<ActionResult> CreateAccount([FromBody] FakePayRequestData request)
        {
            // // Validate the request data and create the account in the database
            // if (request.username == null || request.emailAddress == null || request.password == null)
            // {
            //     return BadRequest("Leeg veld!");
            // }

            // var accountId = await _context.Accounts.ToListAsync();
            // Account account = new Account(request.username, request.emailAddress, request.password, "gebruiker", accountId.Count() +1);
            // _context.Accounts.Add(account);

            // await _context.SaveChangesAsync();
            return Ok(200);
        }
    }
}

public class FakePayRequestData
{
    public int Amount {get; set;}
    public string Reference {get; set;}
    public string Success {get; set;}
}