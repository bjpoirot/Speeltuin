using Shipwharf.ApplicationCore.Entities;
using System;

namespace Shipwharf.Infrastructure
{
    public class EFRepository<T>: BaseEntity
    {
        protected readonly ShipwharfDbContext _dbContext;

        public EFRepository(ShipwharfDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
