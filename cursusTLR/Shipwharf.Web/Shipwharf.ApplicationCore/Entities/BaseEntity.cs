using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.ApplicationCore.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
