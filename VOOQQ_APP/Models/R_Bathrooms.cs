using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class R_Bathrooms
    {
        [Key]
        public long BathroomsId { get; set; }
        public string Name { get; set; }
    }
}