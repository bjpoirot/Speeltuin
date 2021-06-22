using ShipwharfMVCSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public abstract class PageListItemViewModelBase : IPageListItemViewModel
    {

        public Guid Id { get; set; }

        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanDetails { get; set; }

    }
}
