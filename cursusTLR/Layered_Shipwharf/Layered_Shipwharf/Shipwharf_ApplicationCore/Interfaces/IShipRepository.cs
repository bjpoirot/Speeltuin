using Shipwharf.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.ApplicationCore.Interfaces
{
    public interface IShipRepository
    {
        public Task<Ship> CreateShipAsync(Ship ship);
    }
}
