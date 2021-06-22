using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public class ShipDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Hold { get; set; }
        public string Name { get; set; }
        public string EuNumber { get; set; }
        public string Type { get; set; }
    }
}
