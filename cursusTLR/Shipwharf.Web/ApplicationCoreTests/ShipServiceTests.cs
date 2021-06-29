using Shipwharf.ApplicationCore.Entities;
using Shipwharf.ApplicationCore.Services;
using System;
using Xunit;

namespace ApplicationCoreTests
{
    public class ShipServiceTests
    {
        [Fact]
        public async void AddShip()
        {
            var shipService = new ShipService(new FakeShipRepository());
            var ship = new Ship() { Id = Guid.Empty, Name = "TestShip", Hold = 1 };
            var createdShip = await shipService.CreateShipAsync(ship);

            Assert.NotNull(createdShip);
            Assert.NotEqual<Guid>(ship.Id, createdShip.Id);
            Assert.NotEqual<Guid>(Guid.Empty, createdShip.Id);
            Assert.Equal<int>(ship.Hold, createdShip.Hold);

        }
    }
}
