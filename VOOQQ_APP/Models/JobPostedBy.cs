using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class JobPostedBy
    {
        [Key]
        public long JobPostedById { get; set; }
        public string JobPostedByName { get; set; }
    }
}