using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class HotelRoomInternetType
    {
        [Key]
        public long InternetTypeId { get; set; }
        public string InternetTypeName { get; set; }
    }
}