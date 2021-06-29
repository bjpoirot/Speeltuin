using Shipwharf.ApplicationCore.Entities;
using Shipwharf.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCoreTests
{
    class FakeShipRepository : IShipRepository
    {
        private ICollection<Ship> Ships = new List<Ship>()
        {
            new Ship() {Id = Guid.NewGuid(), Name = "Oceanbreeze", Hold = 4 },
            new Ship() {Id = Guid.NewGuid(), Name = "Oceanbreeze II", Hold = 5 }
        };

        public Task<Ship> CreateShipAsync(Ship ship)
        {
            ship.Id = Guid.NewGuid();// Ships.Last(ship.Id + 1);
            Ships.Add(ship);
            return Task.FromResult(ship);
        }
    }
}
