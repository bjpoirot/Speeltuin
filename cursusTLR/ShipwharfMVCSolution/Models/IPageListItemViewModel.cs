using ShipwharfMVCSolution.Data;
using System;

namespace ShipwharfMVCSolution.Models
{
    public interface IPageListItemViewModel
    {
        Guid Id { get; set; }

        bool CanEdit { get; set; }
        bool CanDelete { get; set; }
        bool CanDetails { get; set; }
    }
}