using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFAPIDAY2.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Manufacture { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}