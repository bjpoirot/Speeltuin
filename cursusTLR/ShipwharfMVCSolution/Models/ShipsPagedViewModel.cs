using ShipwharfMVCSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public class ShipsPagedViewModel
    {
        public IReadOnlyCollection<ShipPageListItemViewModel> Ships { get; set; }
        public int TotalPages => (int)Math.Ceiling(_numberOfShips / (double)PageSize);
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        private int _numberOfShips = 0;

       /// public Dictionary<ShipType, int> NumberOfShipsPerType { get; set; }

        public ShipsPagedViewModel(int numberOfShips)
        {
            _numberOfShips = numberOfShips;

            PageNumber = 1;
            PageSize = 2;
        }

        public ShipsPagedViewModel(IReadOnlyCollection<ShipPageListItemViewModel> ships, int numberOfShips)
        {
            Ships = ships;
            _numberOfShips = numberOfShips;
            PageNumber = 1;
            PageSize = 2;
        }
    
    }
}
