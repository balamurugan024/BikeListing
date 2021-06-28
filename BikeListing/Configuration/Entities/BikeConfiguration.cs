using BikeListing.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Configuration.Entities
{
    public class BikeConfiguration : IEntityTypeConfiguration<Bike>
    {
        public void Configure(EntityTypeBuilder<Bike> builder)
        {
            builder.HasData(
                new Bike { Id = 1, Name = "Pulsar 150", Showroom = "Dindigul", Rating = 4.3, BrandId = 1 },
                new Bike { Id = 2, Name = "Hornet 2.0", Showroom = "Dindigul", Rating = 4.5, BrandId = 3 },
                new Bike { Id = 3, Name = "Pulsar NS200", Showroom = "Trichy", Rating = 3.7, BrandId = 1 },
                new Bike { Id = 4, Name = "Xpulse 200T", Showroom = "Madurai", Rating = 3.7, BrandId = 2 }
                );
        }
    }
}
