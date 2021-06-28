using BikeListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
       IGenericRepository<Brand> Brands { get; }
       IGenericRepository<Bike> Bikes { get; }

        Task Save();
    }
}
