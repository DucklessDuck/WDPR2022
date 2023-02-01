using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SecuredController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecuredData()
    {
        var name = User.Identity.Name;
        // Fetch and return the secured data
        return Ok(new { message = "Secured data", name });
    }
}