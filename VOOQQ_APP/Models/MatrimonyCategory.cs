using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class MatrimonyCategory
    {
        [Key]
        public long MatrimonyCategoryId { get; set; }
        public string MatrimonyCategoryName { get; set; }
    }
}