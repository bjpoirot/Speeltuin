using Microsoft.AspNetCore.Mvc.Rendering;
using ShipwharfMVCSolution.Data;
using ShipwharfMVCSolution.Models.ErrorMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipwharfMVCSolution.Models
{
    public class UpdateShipViewModel
    {
        public Guid Id { get; set; }
        [Range(1, 10, ErrorMessage = Constants.RangeErrorMessage)]
        public string Hold { get; set; }
        [Required(ErrorMessage = Constants.RequiredErrorMessage)]
        public string Name { get; set; }
        public string EuNumber { get; set; }
        public int ShipTypeId { get; set; }



    }
}
