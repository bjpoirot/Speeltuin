using Shipwharf.ApplicationCore.Entities;
using Shipwharf.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.ApplicationCore
{
    public class ShipService : IShipService
    {
        public ShipService()
        {

        }
        public Task<Ship> CreateShipAsync(Ship ship)
        {
            throw new NotImplementedException();
        }
    }
}
