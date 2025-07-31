namespace Web_DemoMVCWithEfCodeFirstMasterDetails.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; } // Foreign key to the master entity

        public Category? Category { get; set; } // Navigation property to the master entity
    }
}
