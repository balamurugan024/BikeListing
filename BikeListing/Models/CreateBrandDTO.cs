using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Models
{
    public class CreateBrandDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Brand Name is too Long")]
        public string Name { get; set; }


        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Brand Code is too Long")]
        public string SCode { get; set; }
    }
}
