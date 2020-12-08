using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmShop.Entities {
    public class Order : BaseEntity {
        // own keys
        public DateTime OrderDate { get; set; }
        
        // foreign keys
        public int UserId { get; set; }

        // data annotations
        [ForeignKey("UserId")]
        public User ParentUser { get; set; }
    }
}
