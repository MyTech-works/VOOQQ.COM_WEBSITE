using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Matrimony
    {
        [Key]
        public long MatrimonyId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Category")]
        public long MatrimonyCategoryId { get; set; }
        [Required]
        [Display(Name = "Age Category")]
        public long M_AgeCategoryId { get; set; }
        [Display(Name = "Marital Status")]
        public long M_MaritalStatusId { get; set; }
        [Display(Name = "Physical Status")]
        public long M_PhysicalStatusId { get; set; }
        [Display(Name = "BodySkin Tone")]
        public long M_BodySkinToneId { get; set; }
        [Display(Name = "Religion")]
        public long ReligionId { get; set; }



        public string Community { get; set; }
        [Display(Name = "Sub Community")]
        public string SubCommunity { get; set; }
        public string Nakshatra { get; set; }
        public string Job { get; set; }
        public string Qualification { get; set; }
        public string Languages { get; set; }
       
        
        public string Email { get; set; }
        [Required]
        [Display(Name = "About")]
        public string Description { get; set; }
        [Display(Name = "Land Phone")]
        public string LandPhone { get; set; }
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