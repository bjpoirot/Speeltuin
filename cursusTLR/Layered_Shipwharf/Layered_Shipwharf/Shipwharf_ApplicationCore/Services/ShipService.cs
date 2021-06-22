using Shipwharf.ApplicationCore.Entities;
using Shipwharf.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.ApplicationCore.Services
{
    public class ShipService: IShipService
    {
        private readonly IShipRepository _shipRepository;

        public ShipService(IShipRepository shipRepository)
        {
            this._shipRepository = shipRepository;
        }

        public async Task CreateShipAsync(Ship ship)
        {
            //perform validation and other business rules on entity before
            //calling your Infrastructure layer

            await _shipRepository.CreateShipAsync(ship);
        }
    }
}
