using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Models
{
    public class CreateBikeDTO
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Bike Name is too Long")]
        public string Name { get; set; }


        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Showroom Details are too Long")]
        public string Showroom { get; set; }
        

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }


        [Required]
        public int BrandId { get; set; }
    }


    public class UpdateBikeDTO : CreateBikeDTO
    {

    }
}
