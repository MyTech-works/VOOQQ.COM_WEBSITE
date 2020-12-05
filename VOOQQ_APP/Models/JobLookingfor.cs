using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class JobLookingfor
    {
        [Key]
        public long JobLookingforId { get; set; }
        public string JobLookingforName { get; set; }
    }
}