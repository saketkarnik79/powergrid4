using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_DemoMVCWithEFCoreCodeFirst.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Product Id")]
        [Key]
        public long Id { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
