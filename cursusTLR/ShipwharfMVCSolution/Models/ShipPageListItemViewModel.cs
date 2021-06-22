using ShipwharfMVCSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public class ShipPageListItemViewModel : PageListItemViewModelBase, IPageListItemViewModel
    {
        public string Hold { get; set; }
        public string Name { get; set; }
        public string EuNumber { get; set; }
        public string Type { get; set; }
    }
}
