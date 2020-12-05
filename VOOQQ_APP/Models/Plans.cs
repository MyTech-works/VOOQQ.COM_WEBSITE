using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Plans
    {
        [Key]
        public long PlanId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public long VooqCategoryId { get; set; }
        [Required]
        [Display(Name = "Type Id")]
        public long PlanTypeId { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string PlanTypeName { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public long Duration { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }
        [Required]
        [Display(Name = "Prime")]
        public bool IsPrime { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}