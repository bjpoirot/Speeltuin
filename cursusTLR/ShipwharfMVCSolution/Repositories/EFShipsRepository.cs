using Microsoft.EntityFrameworkCore;
using ShipwharfMVCSolution.Data;
using ShipwharfMVCSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Repositories
{
    public class EFShipsRepository : IShipsRepository
    {
        private readonly ApplicationDbContext _context;
        public EFShipsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShipDetailsViewModel> GetShipDetails(Guid id)
        {
            return await _context.Ships
                .Select(s => new ShipDetailsViewModel()
                {
                    Id = s.Id,
                    Hold = s.Hold,
                    Name = s.Name,
                    Type = s.ShipType.Title
                })
                .FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task<int> GetNumberOfShips()
        {
            return await _context.Ships.CountAsync();
        }


        public async Task<IReadOnlyCollection<ShipPageListItemViewModel>> GetShips(int skip, int take)
        {
            var ships = await _context.Ships
                .Skip(skip)
                .Take(take)
                .Select(s => new ShipPageListItemViewModel()
                {
                    EuNumber = s.EuNumber,
                    Hold = s.Hold,
                    Id = s.Id,
                    Name = s.Name,
                    Type = s.ShipType.Title
                }).ToListAsync();
            return ships;
        }

        public async Task<UpdateShipViewModel> Create(UpdateShipViewModel shipViewModel)
        {

            var ship = new Ship()
            {
                Id = Guid.NewGuid(),
                EuNumber = shipViewModel.EuNumber,
                Hold = shipViewModel.Hold,
                Name = shipViewModel.Name,
                ShipTypeId = shipViewModel.ShipTypeId
            };

            _context.Ships.Add(ship);
            await _context.SaveChangesAsync();

            shipViewModel.Id = ship.Id;

            return shipViewModel;

        }
    }
}
