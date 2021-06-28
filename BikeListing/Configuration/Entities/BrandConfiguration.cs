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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { Id = 1, Name = "Bajaj", SCode = "BAJ" },
                new Brand { Id = 2, Name = "Hero", SCode = "HER" },
                new Brand { Id = 3, Name = "HONDA", SCode = "HON" }
                );
        }
    }
}
