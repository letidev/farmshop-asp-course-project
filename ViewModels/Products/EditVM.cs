using FarmShop.Entities;

using System.ComponentModel.DataAnnotations;

namespace FarmShop.ViewModels.Products {
    public class EditVM {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^\\d*\\,?\\d*$", ErrorMessage = "Number format invalid")]
        public string Price { get; set; }

        public EditVM() { }
        public EditVM(Product p) {
            Id = p.Id;
            Name = p.Name;
            Price = p.CurrentPrice.ToString();
        }
    }


}
