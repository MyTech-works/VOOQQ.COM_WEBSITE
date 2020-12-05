using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class T_QualifiedLevels
    {
        [Key]
        public long QualifiedTeachinglevelsId { get; set; }
        public string Name { get; set; }
        
    }
}