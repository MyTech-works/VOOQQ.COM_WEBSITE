using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Auditoriums
    {
        [Key]
        public long AuditoriumId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }
        [Required]
        [Display(Name = "Category")]
        public long AuditoriumCategoryId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public double Price { get; set; }
        [Display(Name = "Seating Capacity")]
        public string SeatingCapacity { get; set; }
        [Display(Name = "Dining Capacity")]
        public string DiningCapacity { get; set; }
        [Display(Name = "Parking Capacity")]
        public string ParkingCapacity { get; set; }
        [Display(Name = "Type")]
        public long AuditoriumTypeId { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Land Phone")]
        public string LandPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string About { get; set; }

        [Display(Name = "Images 1")]
        public string Image1 { get; set; }
        [Display(Name = "Images 2")]
        public string Image2 { get; set; }
        [Display(Name = "Images 3")]
        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
        public bool Prime { get; set; }
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}