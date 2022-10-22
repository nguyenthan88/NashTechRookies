using System.ComponentModel.DataAnnotations;

namespace EFAPIDAY2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        public ICollection<Product> Products { get; set; } = null!;
    }
}