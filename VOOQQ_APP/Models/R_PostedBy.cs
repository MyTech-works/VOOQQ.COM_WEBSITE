using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class R_PostedBy
    {
        [Key]
        public long PostedById { get; set; }
        public string Name { get; set; }
    }
}