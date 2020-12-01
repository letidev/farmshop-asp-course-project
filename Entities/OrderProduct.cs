using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmShop.Entities {
    public class OrderProduct : BaseEntity {
        // own keys
        public int Quantity { get; set; }

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
