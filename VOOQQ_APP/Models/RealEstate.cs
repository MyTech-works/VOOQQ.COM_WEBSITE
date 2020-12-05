using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class RealEstate
    {
        [Key]
        public long RealEstateId { get; set; }
        public long VId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "CategoryId")]
        public long CategoryId { get; set; }
        [Required]
        [Display(Name = "TypeId")]
        public long TypeId { get; set; }
        [Required]
        [Display(Name = "Condition")]
        public long ConditionId { get; set; }
        [Required]
        [Display(Name = "Ad Square Feet")]
        public string SquareFeet { get; set; }
        [Required]
        [Display(Name = "Bedrooms")]
        public long BedroomsId { get; set; }
        [Required]
        [Display(Name = "Bathrooms")]
        public string BathroomsId { get; set; }
        [Required]
        [Display(Name = "Direction")]
        public long DirectionId { get; set; }
        [Required]
        [Display(Name = "Posted By")]
        public long PostedById { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Description")]
        [StringLength(3000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Description { get; set; }
       
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Images 1")]
        public string Image1 { get; set; }
        [Display(Name = "Images 2")]
        public string Image2 { get; set; }
        [Display(Name = "Images 3")]
        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
       
    }
}