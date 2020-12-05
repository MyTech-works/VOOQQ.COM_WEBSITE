using System;
using System.ComponentModel.DataAnnotations;

namespace VOOQQ_APP.Models
{
    public class CabsTaxi
    {
        [Key]
        public long CabTaxiId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Name")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Vehicle Category")]
        public long VehicleCategoryId { get; set; }
        [Required]
        [Display(Name = "Vehicle Type")]
        public long VehicleTypeId { get; set; }
        [Required]
        public string Location { get; set; }
        [Display(Name = "Driver Age")]
        public long DriverAge { get; set; }
        [Display(Name = "Year of Experience")]
        public long YearofExperience { get; set; }
        [Display(Name = "Vehicle Brand")]
        public string VehicleBrand { get; set; }
        [Display(Name = "Vehicle Model Name")]
        public string VehicleModelName { get; set; }
        [Display(Name = "Vehicle Year")]
        public long VehicleYear { get; set; }
        [Display(Name = "Seating Capacity")]
        public long SeatingCapacity { get; set; }
        [Display(Name = "Minimum Charge")]
        public long MinimumCharge { get; set; }
        [Display(Name = "Mobile Number")]
        public long MobileNumber { get; set; }
        [Display(Name = "Land Phone")]
        public long LandPhone { get; set; }
        public string About { get; set; }
        [Display(Name = "Images 1")]
        public string Image1 { get; set; }
        [Display(Name = "Images 2")]
        public string Image2 { get; set; }
        [Display(Name = "Images 3")]
        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Prime { get; set; }
        public bool Status { get; set; }
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}