using System.ComponentModel.DataAnnotations;

namespace Web_DemoMVCConcepts.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product Name should be between 3 character and 50 characters in length.")]
        [Display(Name = "Product Name")]
        public string? Name { get; set; }

        [Display(Name = "Product Description")]
        [MaxLength(200, ErrorMessage = "Description should not exceed 200 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }
    }
}
