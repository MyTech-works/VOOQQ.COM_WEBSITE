using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class HotelRoomClassType
    {
        [Key]
        public long ClassTypeId { get; set; }
        public string ClassTypeName { get; set; }
    }
}