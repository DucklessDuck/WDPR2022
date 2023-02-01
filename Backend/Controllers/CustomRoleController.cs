using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Controllers
{
    // [Authorize(Roles = "admin")]
    [Route("[controller]")]
    [ApiController]
    public class CustomRoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CustomRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: api/ApplicationRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles == null)
            {
                return NotFound();
            }
            return roles;
        }

        // GET: api/ApplicationRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityRole>> GetRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        // POST: api/ApplicationRole
        [HttpPost]
        public async Task<ActionResult<IdentityRole>> CreateRole(RequestDataRole applicationRoleDTO)
        {
            var role = new IdentityRole { Name = applicationRoleDTO.RoleName};
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }


        // PUT: api/ApplicationRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRole(string id, RequestDataRole applicationRoleDTO)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            if (role.Name == "root")
            {
                return StatusCode(StatusCodes.Status403Forbidden, "The root role cannot be modified.");
            }
            role.Name = applicationRoleDTO.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }


        // DELETE: api/ApplicationRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            if (role.Name == "root")
            {
                return StatusCode(StatusCodes.Status403Forbidden, "The root role cannot be deleted.");
            }
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
        
         public class RequestDataRole
        {
            public string RoleName{get; set; }
        }
    }
}