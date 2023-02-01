using Microsoft.AspNetCore.Identity;
using Models;
public class CustomRole : IdentityRole
{
    public CustomRole() : base() { }
    public CustomRole(string roleName) : base(roleName) { }
    public string Description { get; set; }
    public virtual Account Account {get; set;}
    public virtual IdentityRole Role {get; set;}
    
}