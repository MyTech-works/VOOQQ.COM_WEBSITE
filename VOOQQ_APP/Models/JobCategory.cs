using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class JobCategory
    {
        [Key]
        public long JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
    }
}