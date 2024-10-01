
using Ecommerce.Data.Entities;

public class ProductBrand:BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
