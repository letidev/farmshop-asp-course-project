using System.ComponentModel.DataAnnotations.Schema;

namespace FarmShop.Entities {
    public class User : BaseEntity {
        // own keys
        public string Username { get; set; }
        public string Password { get; set; }
        // we won't "actually" delete users
        // because that would create problems
        // for the orders or if we enable cascade deletion
        // that would erase a lot of data
        public bool IsDeleted { get; set; }

        // foreign keys
        public int RoleId { get; set; }

        // data annotations
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
