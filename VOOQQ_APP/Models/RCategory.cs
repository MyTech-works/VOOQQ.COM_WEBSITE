using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class RCategory 
    {
        [Key]
        public long RCategoryId { get; set; }
        public string EducationCategoryName { get; set; }
    }
}