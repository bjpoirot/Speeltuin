using System;

namespace Shipwharf.ApplicationCore.Entities
{
    public class Ship : BaseEntity
    {       
        public string Hold { get; set; }
        public string Name { get; set; }
        public string EuNumber { get; set; }
        public int ShipTypeId { get; set; }
        public ShipType ShipType { get; set; }
    }
}
