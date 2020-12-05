using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class EducationType
    {
        [Key]
        public long EducationTypeId { get; set; }
        public string EducationTypeName { get; set; }
    }
}