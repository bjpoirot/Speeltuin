using System;

namespace ShipwharfMVCSolution.Models
{
    public abstract class PagedViewModelBase
    {

        protected int _numberOfItems = 0;
        public int TotalPages => (int)Math.Ceiling(_numberOfItems / (double)PageSize);
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PagedViewModelBase(int numberOfShips)
        {
            _numberOfItems = numberOfShips;
        }
    }
}