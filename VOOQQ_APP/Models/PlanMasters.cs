using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class PlanMasters
    {
        [Key]
        public long PlanMastersId { get; set; }
        public long VId { get; set; }
        public string PlanType { get; set; }
        public string PlanName { get; set; }
        public int PlanDays { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public string Feaures1 { get; set; }
        public string Feaures2 { get; set; }
        public string Feaures3 { get; set; }
        public string Feaures4 { get; set; }
        public string Feaures5 { get; set; }
        public bool IsActive { get; set; }

    }
}