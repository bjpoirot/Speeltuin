using ShipwharfMVCSolution.Data;
using ShipwharfMVCSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Repositories
{
    public interface IShipsRepository
    {
        Task<ShipDetailsViewModel> GetShipDetails(Guid id);
        Task<int> GetNumberOfShips();
        Task<IReadOnlyCollection<ShipPageListItemViewModel>> GetShips(int skip, int take);

    }
}
