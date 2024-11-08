using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenVanLinh_22115053122225.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int userId { get; set; } // Primary Key

        [Required]
        public string userName { get; set; }

        [Required]
        public string email { get; set; }

        public string password { get; set; }

        // Navigation property to represent the one-to-many relationship with GioHang
        public ICollection<GioHang> GioHangs { get; set; }
    }
}
