using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class BusinessCategory
    {

        [Key]
        public long BusinessCategoryId { get; set; }
        public string BusinessCategoryName { get; set; }

    }
}