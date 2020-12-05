using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class M_BodySkinTone
    {

        [Key]
        public long M_BodySkinToneId { get; set; }
        public string M_BodySkinToneName { get; set; }
    }
}