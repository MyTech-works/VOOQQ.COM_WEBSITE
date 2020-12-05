using System.ComponentModel.DataAnnotations;

namespace VOOQQ_APP.Models
{
    public class AuditoriumType
    {
        [Key]
        public long AuditoriumTypeId { get; set; }
        public string AuditoriumTypeName { get; set; }
    }
}