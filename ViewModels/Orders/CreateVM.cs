using FarmShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmShop.ViewModels.Orders {
    public class CreateVM {
        public List<Product> Products { get; set; }
        public int[] Ids { get; set; }
        public int[] Quantities { get; set; }
    }
}
