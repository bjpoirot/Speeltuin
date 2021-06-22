using Shipwharf.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.Infrastructure
{
    public class ShipRepository : EFRepository<Ship>, IShipRepository
    {
        public ShipRepository(ShipwharfDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Ship> CreateShipAsync(Ship ship)
        {
            await _dbContext.Ships.AddAsync(ship);
            await _dbContext.SaveChangesAsync();
            return ship;
        }
    }
}
