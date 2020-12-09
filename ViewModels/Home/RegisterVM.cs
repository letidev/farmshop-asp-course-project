using System.ComponentModel.DataAnnotations;

namespace FarmShop.ViewModels.Home {
    public class RegisterVM : LoginVM {
        [Required(ErrorMessage = "* This field is required!")]
        public string ConfirmPassword { get; set; }
    }
}
