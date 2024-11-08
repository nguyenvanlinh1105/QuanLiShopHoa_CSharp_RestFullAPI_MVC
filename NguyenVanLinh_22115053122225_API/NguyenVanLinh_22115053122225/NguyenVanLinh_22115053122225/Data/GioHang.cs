using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenVanLinh_22115053122225.Data
{
    [Table("GioHang")]
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; } // Primary Key

        [ForeignKey("User")]
        public int UserId { set; get; }
        public User User { set; get; }

        public ICollection<Hoa> hoas { get; set; }

    }
}
