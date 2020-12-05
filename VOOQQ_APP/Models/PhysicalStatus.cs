using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class PhysicalStatus
    {
        [Key]
        public long PhysicalStatusId { get; set; }
        public string PhysicalStatusName { get; set; }
    }
}