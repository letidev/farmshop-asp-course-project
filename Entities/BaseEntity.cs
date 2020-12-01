using System.ComponentModel.DataAnnotations;

namespace FarmShop.Entities {
    public class BaseEntity {
        [Key]
        public int Id { get; set; }
    }
}
