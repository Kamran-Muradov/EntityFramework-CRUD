using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkConsole.Models
{
    public class Country : BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Population { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
