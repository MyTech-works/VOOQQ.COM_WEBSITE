using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class ServiceCategory
    {
        [Key]
        public long ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
    }
}