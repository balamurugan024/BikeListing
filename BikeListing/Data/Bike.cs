using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Data
{
    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Showroom { get; set; }
        public double Rating { get; set; }
        
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        
    }
}
    