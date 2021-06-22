using ShipwharfMVCSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public class ShipTypePageListItemViewModel : PageListItemViewModelBase, IPageListItemViewModel
    {
        public string Title { get; set; }
        public int Count { get; set; }
    }
}
