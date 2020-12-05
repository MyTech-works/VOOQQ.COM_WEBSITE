using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class BodySkinTone
    {
        [Key]
        public long BodySkinToneId { get; set; }
        public string BodySkinToneName { get; set; }

    }
}