using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmShop.ViewModels.Products {
    public class CreateVM {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^\\d*\\,?\\d*$", ErrorMessage = "Number format invalid")]
        public string Price { get; set; }
    }
}
