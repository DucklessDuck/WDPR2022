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

         public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

    }
}


