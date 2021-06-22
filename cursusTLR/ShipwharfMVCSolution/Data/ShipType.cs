using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Data
{
    public class ShipType : EntityTypeBase
    {
        public List<Ship> Ships { get; set; }
    }
}
