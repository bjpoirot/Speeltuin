using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Data
{
    public class Ship
    {
        public Guid Id { get; set;}
        public string Hold { get; set; }
        public string Name { get; set; }
        public string EuNumber { get; set; }
        public int ShipTypeId { get; set; }
        public ShipType ShipType { get; set; }
    }
}
