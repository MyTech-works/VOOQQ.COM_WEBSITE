using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class MaritalStatus
    {
        [Key]
        public long MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; }
    }
}