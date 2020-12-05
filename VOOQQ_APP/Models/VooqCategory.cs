using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class VooqCategory
    {
        [Key]
        public long RefId { get; set; }
        [Required]
        public long VooqCategoryId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}