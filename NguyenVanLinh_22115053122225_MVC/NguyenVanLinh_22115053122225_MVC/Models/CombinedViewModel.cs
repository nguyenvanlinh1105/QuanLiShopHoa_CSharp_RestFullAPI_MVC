using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenVanLinh_22115053122225_MVC.Models
{
    public class CombinedViewModel
    {
        public List<DanhMucHoa> dsDanhMuc { set; get; }
        public List<Hoa> dsHoa { set; get; }
        public List<Hoa> dsHoaByID { set; get; }
        public Hoa chitietHoa { set; get; }
    }
}