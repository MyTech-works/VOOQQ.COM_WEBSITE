using System.ComponentModel.DataAnnotations;

namespace VOOQQ_APP.Models
{
    public class AuditoriumCategory
    {
        [Key]
        public long AuditoriumCategoryId { get; set; }
        public string AuditoriumCategoryName { get; set; }
    }
}