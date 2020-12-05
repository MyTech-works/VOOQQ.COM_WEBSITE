using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class T_Availability
    {
        [Key]
        public long T_AvailabilityId { get; set; }
        public string T_AvailabilityName { get; set; }
    }
}