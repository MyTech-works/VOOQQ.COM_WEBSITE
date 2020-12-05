using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class M_PhysicalStatus
    {

        [Key]
        public long M_PhysicalStatusId { get; set; }
        public string M_PhysicalStatusName { get; set; }
    }
}