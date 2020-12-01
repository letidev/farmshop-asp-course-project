using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmShop.Entities {
    public class User : BaseEntity {
        // own keys
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isDeleted { get; set; }

        // foreign keys
        public int RoleId { get; set; }

        // data annotations
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
