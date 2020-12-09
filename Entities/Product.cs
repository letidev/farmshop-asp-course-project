namespace FarmShop.Entities {
    public class Product : BaseEntity {
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        // we won't "actually" delete products because that would 
        // create problems for the order products
        public bool IsDeleted { get; set; }

        // constructors
        public Product() { }
        public Product(string name, decimal price) {
            Name = name;
            CurrentPrice = price;
            IsDeleted = false;
        }
    }
}
