using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Bike> Bikes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name="Bajaj", SCode="BAJ"},
                new Brand { Id = 2, Name = "Hero", SCode = "HER" },
                new Brand { Id = 3, Name = "HONDA", SCode = "HON" }
                );

            builder.Entity<Bike>().HasData(
                new Bike { Id=1,Name="Pulsar 150", Showroom ="Dindigul",Rating=4.3,BrandId=1 },
                new Bike { Id = 2, Name = "Hornet 2.0", Showroom = "Dindigul", Rating = 4.5, BrandId = 3 },
                new Bike { Id = 3, Name = "Pulsar NS200", Showroom = "Trichy", Rating = 3.7, BrandId = 1 },
                new Bike { Id = 4, Name = "Xpulse 200T", Showroom = "Madurai", Rating = 3.7, BrandId = 2 }
                );
        }

    }
}
