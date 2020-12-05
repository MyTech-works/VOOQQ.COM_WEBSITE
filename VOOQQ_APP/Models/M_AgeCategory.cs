using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class M_AgeCategory
    {

        [Key]
        public long M_AgeCategoryId { get; set; }
        public string M_AgeCategoryName { get; set; }
    }
}