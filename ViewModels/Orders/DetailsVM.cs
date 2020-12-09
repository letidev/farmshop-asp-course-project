using FarmShop.Entities;
using System.Collections.Generic;

namespace FarmShop.ViewModels.Orders {
    public class DetailsVM {
        public Order Order { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
