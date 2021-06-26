using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Data
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SCode { get; set; }

        public virtual IList<Bike> Bikes { get; set; }

    }
}
