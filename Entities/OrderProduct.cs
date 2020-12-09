using System.ComponentModel.DataAnnotations.Schema;

namespace FarmShop.Entities {
    public class OrderProduct : BaseEntity {
        // own keys
        public int Quantity { get; set; }
        // the product in the order is sold with the current
        // price of the product and is kept as history
        // at some point the price of the original product
        // may change e.g. become more expensive or have a discount
        public decimal PriceSold { get; set; }

        // foreign keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // data annotations
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
