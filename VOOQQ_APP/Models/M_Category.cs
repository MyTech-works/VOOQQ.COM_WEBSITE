using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class M_Category
    {
        [Key]
        public long M_CategoryId { get; set; }
        public string M_CategoryName { get; set; }
    }
}