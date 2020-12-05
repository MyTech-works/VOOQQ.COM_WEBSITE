using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Job
    {
        [Key]
        public long JobId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Job Category")]
        public long JobCategoryId { get; set; }
        [Required]
        public double Salary { get; set; }
        [Display(Name = "Posted By")]
        public long PostedById { get; set; }
        [Display(Name = "Status")]
        public long StatusId { get; set; }
        [Display(Name = "Looking for")]
        public long LookingforId { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        [Display(Name = "Land Phone")]
        public string LandPhone { get; set; }
        [Required]
        [Display(Name = "Email ID")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "About")]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public DateTime Date { get; set; }

        public double Views { get; set; }
        public bool Prime { get; set; }
        public bool Status { get; set; }
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}