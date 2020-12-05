using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class R_SquareFeet
    {
        [Key]
        public long SquareFeetId { get; set; }
        public string Name { get; set; }
    }
}