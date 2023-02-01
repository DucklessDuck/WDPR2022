using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models;

public class DatabaseContext : IdentityDbContext<Account>
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<BetrokkenPersoon> Crews { get; set; }
    public DbSet<Kaart>? Tickets { get; set; }
    public DbSet<Voorstelling> Voorstellingen { get; set; }
    public DbSet<Zaal> Zalen { get; set; }
    public DbSet<Stoel> Stoelen { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options){}

    protected override void OnModelCreating(ModelBuilder builder) {
        //Fluent API
        base.OnModelCreating(builder);
    }
    public DbSet<CustomRole> ApplicationUserRole { get; set; } = default!;
}


