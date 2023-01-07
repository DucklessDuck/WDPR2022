using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BetrokkenPersoon> Crews { get; set; }
        public DbSet<Kaart>? Tickets { get; set; }
        public DbSet<Voorstelling> Voorstellingen { get; set; }
        public DbSet<Zaal> Zalen { get; set; }
        public DbSet<Stoel> Stoelen { get; set; }

        public string DbPath { get; }

        public DatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "theaterLaak.db");
        }
    
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Account>()
                    .HasMany(p => p.TicketLijst)
                    .WithOne(b => b.Bezoeker);

                modelBuilder.Entity<BetrokkenPersoon>()
                    .HasMany(p => p.Voorstellingen)
                    .WithMany(p => p.Crew);
                    
                
                modelBuilder.Entity<Voorstelling>()
                    .HasMany(p => p.Tickets)
                    .WithOne(P => P.voorstelling);

                modelBuilder.Entity<Zaal>()
                    .HasMany(p => p.Stoelen)
                    .WithOne(p => p.Zaal);
            }
            
            public void CreateAccount(string username, string password)
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    Account newAccount = new Account
                    {
                        Gebruikersnaam = username,
                        Wachtwoord = password
                    };

                    context.Accounts.Add(newAccount);
                    context.SaveChanges();
                }
            }

    }
}


