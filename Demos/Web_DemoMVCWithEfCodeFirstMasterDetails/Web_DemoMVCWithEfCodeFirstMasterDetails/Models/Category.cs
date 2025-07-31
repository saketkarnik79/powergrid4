
namespace Web_DemoMVCWithEfCodeFirstMasterDetails.Models
{
    public class Category//Master Entity
    {
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; } // Navigation property to the details entities
    }
}
