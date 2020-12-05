using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class M_MaritalStatus
    {

        [Key]
        public long M_MaritalStatusId { get; set; }
        public string M_MaritalStatusName { get; set; }
    }
}