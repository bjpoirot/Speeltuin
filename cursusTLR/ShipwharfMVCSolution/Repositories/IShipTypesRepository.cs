using ShipwharfMVCSolution.Data;
using ShipwharfMVCSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Repositories
{
    public interface IShipTypesRepository
    {
        Task<int> GetNumberOfShipTypes();
        Task<IReadOnlyCollection<ShipTypePageListItemViewModel>> GetShipTypes(int skip, int take);

    }
}
