using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenVanLinh_22115053122225.Data
{
    [Table("DanhMucHoa")]
    public class DanhMucHoa
    {
        [Key]
        public int MaDM { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenDM { get; set; }

        [MaxLength(500)]
        public string Mota { get; set; }
        public ICollection<Hoa> Hoas { get; set; }
    }
}
