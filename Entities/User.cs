using System.ComponentModel.DataAnnotations.Schema;
using BC = BCrypt.Net.BCrypt;

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

        // constructors
        public User() { }
        public User(string username, string password, int roleId) {
            Username = username;
            Password = BC.HashPassword(password);
            RoleId = roleId;
        }
    }
}
