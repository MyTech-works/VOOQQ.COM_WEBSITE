using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class ForsaleModel
    {
        public long ForsaleId { get; set; }
        public long VId { get; set; }
       
        public string Title { get; set; }
     
        public string CategoryName { get; set; }
      
        public string TypeName { get; set; }
        public string Email { get; set; }
       
        public string ConditionName { get; set; }

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
        public bool Prime { get; set; }
    }
}