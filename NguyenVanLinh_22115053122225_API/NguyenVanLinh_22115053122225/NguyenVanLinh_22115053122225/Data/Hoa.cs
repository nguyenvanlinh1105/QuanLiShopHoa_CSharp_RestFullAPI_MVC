using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenVanLinh_22115053122225.Data
{
    [Table("Hoa")]
    public class Hoa
    {
        [Key]
        public int MaH { get; set; }

        [ForeignKey("DanhMucHoa")]
        public int MaDM { get; set; }
        [ForeignKey("gioHang")]
        public int MaGioHang { get; set; }


        [Required]
        [MaxLength(100)]
        public string Ten { get; set; }

        [MaxLength(50)]
        public string Donvitinh { get; set; }

        public decimal Dongia { get; set; }

        public int Soluong { get; set; }

        [MaxLength(500)]
        public string MoTa { get; set; }

        public string Hinhanh { get; set; }

        // Navigation property for DanhmucHoa
        public DanhMucHoa DanhMucHoa { get; set; }
        public GioHang gioHang { get; set; }
    }
}
