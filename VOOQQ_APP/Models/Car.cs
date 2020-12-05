using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Car
    {
        [Key]
        public long CarId { get; set; }
        public long VId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "CategoryId")]
        public long CategoryId { get; set; }
        [Required]
        [Display(Name = "TypeId")]
        public long TypeId { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public long BrandId { get; set; }
        [Required]
        [Display(Name = "Fuel")]
        public long FuelId { get; set; }
        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; }
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Direction")]
        public long DirectionId { get; set; }
        [Required]
        [Display(Name = "KM Driven")]
        public string KM { get; set; }
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