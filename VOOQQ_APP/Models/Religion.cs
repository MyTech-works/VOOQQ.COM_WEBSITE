using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Religion
    {
        [Key]
        public long ReligionId { get; set; }
        public string ReligionName { get; set; }
    }
}