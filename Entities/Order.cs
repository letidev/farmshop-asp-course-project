using System.ComponentModel.DataAnnotations.Schema;

namespace FarmShop.Entities {
    public class Order : BaseEntity {
        // foreign keys
        public int UserId { get; set; }

        // data annotations
        [ForeignKey("UserId")]
        public User ParentUser { get; set; }
    }
}
