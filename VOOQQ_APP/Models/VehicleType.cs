using System.ComponentModel.DataAnnotations;

namespace VOOQQ_APP.Models
{
    public class VehicleType
    {
        [Key]
        public long VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
    }
}