using ShipwharfMVCSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public class ShipTypesViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NumberOfShips { get; set; }
    }
}
