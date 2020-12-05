using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Forsale
    {
        [Key]
        public long ForsaleId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Category")]
        public long CategoryId { get; set; }
        [Required]
        [Display(Name = "Type")]
        public long TypeId { get; set; }
        [Required]
        [Display(Name = "Condition")]
        public long ConditionId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [StringLength(3000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "About")]
        public string Description { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
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