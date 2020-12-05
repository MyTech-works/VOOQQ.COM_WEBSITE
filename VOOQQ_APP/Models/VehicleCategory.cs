using System.ComponentModel.DataAnnotations;

namespace VOOQQ_APP.Models
{
    public class VehicleCategory
    {
        [Key]
        public long VehicleCategoryId { get; set; }
        public string VehicleCategoryName { get; set; }
    }
}