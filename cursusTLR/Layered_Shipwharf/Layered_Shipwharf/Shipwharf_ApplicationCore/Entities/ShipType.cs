using System.Collections.Generic;

namespace Shipwharf.ApplicationCore.Entities
{
    public class ShipType : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Ship> Ships { get; set; }
    }
}