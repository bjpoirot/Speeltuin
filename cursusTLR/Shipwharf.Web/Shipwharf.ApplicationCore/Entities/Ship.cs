using System;

namespace Shipwharf.ApplicationCore.Entities
{

    public class Ship : BaseEntity 
    {       
        public int Hold { get; set; }
        public string Name { get; set; }
        public string EuNumber { get; set; }
        public int TypeId { get; set; }
        public ShipType Type { get; set; }
    }
}
