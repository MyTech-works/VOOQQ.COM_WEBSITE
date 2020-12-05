using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class Pet
    {

        [Key]
        public long PetId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Title")]
        public string Title { get; set; }
       
        [Required]
        [Display(Name = "About")]
        public string Description { get; set; }
        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        [Required]
        public string Location { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        [Required]
        [Display(Name = "Category")]
        public long CategoryId { get; set; }
    }
}