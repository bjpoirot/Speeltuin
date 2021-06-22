using Shipwharf.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.Infrastructure
{
    public class EFRepository<T> where T: BaseEntity
    {
        protected readonly ShipwharfDbContext _dbContext;
        public EFRepository(ShipwharfDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
