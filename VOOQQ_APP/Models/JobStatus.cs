using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class JobStatus
    {
        [Key]
        public long JobStatusId { get; set; }
        public string JobStatusName { get; set; }
    }
}