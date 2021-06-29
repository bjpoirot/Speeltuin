using Shipwharf.ApplicationCore.Entities;
using Shipwharf.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.ApplicationCore.Services
{
    public class ShipService : IShipService
    {
        private readonly IShipRepository _shipRepository;

        public ShipService(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }
        public async Task<Ship> CreateShipAsync(Ship ship)
        {
            //perform validation and other business rules on entity before
            //calling your Infrastructure layer
            if (ship == null)
            {
                throw new ArgumentNullException("Ship mag niet null zijn");
            }
            if(ship.Hold < 1 || ship.Hold > 10)
            {
                throw new ArgumentOutOfRangeException($"Hold moet een waarde tussen {0} en {10} zijn");
            }

            var newShip = await _shipRepository.CreateShipAsync(ship);
            return newShip;
        }
    }
}
