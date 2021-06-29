using Shipwharf.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipwharf.ApplicationCore.Entities
{
    public class ShipType : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Ship> Ships { get; set; }
    }
}
