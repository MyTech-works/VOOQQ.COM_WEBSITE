using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Teacher
    {
        [Key]
        public long TeacherId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]          
        [Display(Name = "Name")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Qualified Teaching levels")]
        public long QualifiedTeachinglevelsId { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public long GenderId { get; set; }
        [Required]
        [Display(Name = "Subject")]
        public long SubjectId { get; set; }
        


        [Display(Name = "Years Of Experience")]
        public string YearsOfExperience { get; set; }
        public string LandPhone { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Display(Name = "About")]
        public string Description { get; set; }
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Availability")]
        public long Availability { get; set; }
        public bool Prime { get; set; }
    }
}