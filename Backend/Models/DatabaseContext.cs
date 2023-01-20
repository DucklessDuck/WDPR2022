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

        

        //Rename Tables
        // builder.HasDefaultSchema("Identity");
        // builder.Entity<Account>(entity =>
        // {
        //     entity.ToTable(name: "User");
        // });
        // builder.Entity<Account>(entity =>
        // {
        //     entity.ToTable(name: "Role");
        // });
        // builder.Entity<Account>(entity =>
        // {
        //     entity.ToTable("UserRoles");
        // });
        // builder.Entity<Account>(entity =>
        // {
        //     entity.ToTable("UserClaims");
        // });
        // builder.Entity<Account>(entity =>
        // {
        //     entity.ToTable("UserLogins");
        // });
        // builder.Entity<Account>(entity =>
        // {
        //     entity.ToTable("RoleClaims");
        // });
        // builder.Entity<Account>(entity =>
        // {
        //     entity.ToTable("UserTokens");
        // });

        //Configure 
        
        // builder.Entity<Account>().HasMany(u => u.R).WithRequired().HasForeignKey(ur => ur.UserId);
        // builder.Entity<Account>().HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
        // builder.Entity<Account>().Property(u => u.UserName)
        //     .IsRequired()
        //     .HasMaxLength(256)
        //     .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));
                
        builder.Entity<Account>().Property(u => u.Email).HasMaxLength(256);

        // builder.Entity<Account>()
        //     .HasMany(u => u.Role)
        //     .WithRequired(a => a.user)
        //     .HasForeignKey(a => a.UserId);
    }
}


