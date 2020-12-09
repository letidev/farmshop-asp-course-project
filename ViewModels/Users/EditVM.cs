using System.ComponentModel.DataAnnotations;

namespace FarmShop.ViewModels.Users {
    public class EditVM {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "* This field is required!")]
        public string Username { get; set; }
    }
}
