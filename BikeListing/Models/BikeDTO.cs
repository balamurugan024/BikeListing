using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Models
{
    public class BikeDTO: CreateBikeDTO
    {
        public int Id { get; set; }
        public BrandDTO Brand { get; set; }
        
    }
}
