using AutoMapper;
using BikeListing.Data;
using BikeListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Configuration
{
    public class MapperInitializer: Profile
    {
        public MapperInitializer()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Bike, BikeDTO>().ReverseMap();
            CreateMap<Bike, CreateBikeDTO>().ReverseMap();
        }

    }
}
