using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class HotelRoomPropertyType
    {
        [Key]
        public long PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
    }
}