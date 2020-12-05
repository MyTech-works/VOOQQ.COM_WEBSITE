using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class DoctorCategory
    {
        [Key]
        public long DoctorCategoryId { get; set; }
        public string DoctorCategoryName { get; set; }
    }
}