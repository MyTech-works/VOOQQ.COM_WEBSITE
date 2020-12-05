using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class HotelRooms
    {
        [Key]
        public long HotelRoomId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Property Name")]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Property Type")]
        public long PropertyTypeId { get; set; }
        [Display(Name = "Class")]

        public long ClassTypeId { get; set; }
        [Display(Name = "Check In")]
        public string CheckIn { get; set; }
        [Display(Name = "Check Out")]
        public string CheckOut { get; set; }
        [Display(Name = "Internet")]
        public long InternetTypeID { get; set; }
        [Display(Name = "Parking")]
        public bool IsParking { get; set; }
        [Display(Name = "Breakfast")]
        public bool IsBreakfast { get; set; }
        [Display(Name = "Lift/Escalator")]
        public bool IsEscalator { get; set; }
        [Display(Name = "Room Service")]
        public bool IsRoomService { get; set; }
        [Display(Name = "Restaurant")]
        public bool IsRestaurant { get; set; }
        [Display(Name = "Bar")]
        public bool IsBar { get; set; }
        [Display(Name = "Spa/Massage")]
        public bool IsSpaMassage { get; set; }
        [Display(Name = "Swimming Pool")]
        public bool IsSwimmingPool { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Land Phone")]
        public string LandPhone { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        [Display(Name = "About")]
        public string Description { get; set; }
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