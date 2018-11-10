using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Klase;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace seminarski.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Auto> Auto { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=seminarski;Trusted_Connection=True;MultipleActiveResultSets=true");
        }





        // Add additional items here as needed




    }
}
