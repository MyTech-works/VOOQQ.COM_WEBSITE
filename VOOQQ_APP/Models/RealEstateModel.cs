using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class RealEstateModel
    {
        [Key]
        public long RealEstateId { get; set; }
        public long VId { get; set; }
      
        public string Title { get; set; }
       
        public long CategoryId { get; set; }
       
        public long TypeId { get; set; }
      
        public long ConditionId { get; set; }
      
       
        public string SquareFeet { get; set; }
        
        public long BedroomsId { get; set; }
       
        public string BathroomsId { get; set; }
       
        public long DirectionId { get; set; }
        
        public long PostedById { get; set; }

        public double Price { get; set; }
      
        public string Description { get; set; }

       
        public string Mobile { get; set; }
       
        public string Location { get; set; }
      
        public string Image1 { get; set; }
     
        public string Image2 { get; set; }
        
        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
    }
}