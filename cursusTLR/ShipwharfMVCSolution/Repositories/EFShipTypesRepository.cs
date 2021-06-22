using Microsoft.EntityFrameworkCore;
using ShipwharfMVCSolution.Data;
using ShipwharfMVCSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Repositories
{
    public class EFShipTypesRepository : IShipTypesRepository
    {
        private readonly ApplicationDbContext _context;
        public EFShipTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> GetNumberOfShipTypes()
        {
            return await _context.Ships.CountAsync();
        }


        public async Task<IReadOnlyCollection<ShipTypePageListItemViewModel>> GetShipTypes(int skip, int take)
        {
            var shiptypes = await _context.ShipTypes
                .Skip(skip)
                .Take(take).Select(s => new ShipTypePageListItemViewModel()
                {
                    Title = s.Title,
                    Count = s.Ships.Count
                }).ToListAsync();

            return shiptypes;
        }
    }
}
