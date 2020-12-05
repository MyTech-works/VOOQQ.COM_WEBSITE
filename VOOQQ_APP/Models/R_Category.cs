using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class R_Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string categoryName { get; set; }
    }
}

