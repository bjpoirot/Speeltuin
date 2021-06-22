using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public class PagedViewModel<T> : PagedViewModelBase
    {
        public IReadOnlyCollection<T> Items { get; set; }

        public PagedViewModel(int numberOfItems) : base(numberOfItems)
        {
            _numberOfItems = numberOfItems;
            PageNumber = 1;
            PageSize = 2;
        }

        public PagedViewModel(IReadOnlyCollection<T> items,int numberOfItems) : base(numberOfItems)
        {
            Items = items;
            PageNumber = 1;
            PageSize = 2;
        }
    }
}
