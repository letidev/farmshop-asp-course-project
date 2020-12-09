using FarmShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmShop.ViewModels.Products {
    public class IndexVM {
        public List<Product> Items { get; set; }

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }

        public string Name { get; set; }
        public int Id { get; set; }

        [RegularExpression("^\\d*\\,?\\d*$", ErrorMessage = "Number format invalid")]
        public string Price { get; set; }
    }
}
