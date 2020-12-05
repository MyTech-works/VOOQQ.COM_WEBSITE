using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class R_Type
    {
        [Key]
        public long TypeId { get; set; }
        public string TypeName { get; set; }
    }
}