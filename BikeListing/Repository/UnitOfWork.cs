using BikeListing.Data;
using BikeListing.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Brand> _brands;
        private IGenericRepository<Bike> _bikes;


        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Brand> Brands => _brands ??= new GenericRepository<Brand>(_context);
        public IGenericRepository<Bike> Bikes => _bikes ??= new GenericRepository<Bike>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
