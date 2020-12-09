using FarmShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmShop.ViewModels.Orders {
    public class IndexVM {
        public List<Order> Items { get; set; }

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }

        public string Username { get; set; }
        public int Id { get; set; }
    }
}
