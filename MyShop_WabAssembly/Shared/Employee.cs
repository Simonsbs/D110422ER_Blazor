using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Shared {
    public class Employee {
        public int ID { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "First name must be at least 3 chars")]
        [MaxLength(50, ErrorMessage = "First name must be less then 50 chars")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Last name must be at least 4 chars")]
        [MaxLength(60, ErrorMessage = "Last name must be less then 60 chars")]
        public string LastName { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public byte[] ImageData { get; set; }
    }
}