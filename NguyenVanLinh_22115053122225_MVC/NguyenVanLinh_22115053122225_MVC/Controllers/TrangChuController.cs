using Newtonsoft.Json;
using NguyenVanLinh_22115053122225_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NguyenVanLinh_22115053122225_MVC.Controllers
{
    public class TrangChuController : Controller
    {
        public async Task<ActionResult> Index()
        {

            string apiUrlDanhMuc = "https://localhost:5001/api/DanhMucHoa";// lấy tất cả danh mục
            string apiUrlSanPham = "https://localhost:5001/api/Hoa"; // lấy tất cả sản phẩm 

            // Tạo HttpClient để gọi API
            using (HttpClient client = new HttpClient())
            {
                // Gọi API danh mục
                HttpResponseMessage responseDanhMuc = await client.GetAsync(apiUrlDanhMuc);
                List<DanhMucHoa> danhMucData = new List<DanhMucHoa>();

                if (responseDanhMuc.IsSuccessStatusCode)
                {
                    var jsonDataDanhMuc = await responseDanhMuc.Content.ReadAsStringAsync();
                    danhMucData = JsonConvert.DeserializeObject<List<DanhMucHoa>>(jsonDataDanhMuc);
                }
                else
                {
                    ViewBag.ErrorDanhMuc = "Không thể lấy dữ liệu danh mục từ API.";
                }

                // Gọi API sản phẩm
                HttpResponseMessage responseSanPham = await client.GetAsync(apiUrlSanPham);
                List<Hoa> sanPhamData = new List<Hoa>();

                if (responseSanPham.IsSuccessStatusCode)
                {
                    var jsonDataSanPham = await responseSanPham.Content.ReadAsStringAsync();
                    sanPhamData = JsonConvert.DeserializeObject<List<Hoa>>(jsonDataSanPham);
                }
                else
                {
                    ViewBag.ErrorSanPham = "Không thể lấy dữ liệu sản phẩm từ API.";
                }
                CombinedViewModel model = new CombinedViewModel
                {
                    dsDanhMuc = danhMucData,
                    dsHoa = sanPhamData
                };

                var userSession = Session["LoggedInUser"] as User;
                if (userSession != null)
                {
                    ViewBag.UserName = userSession.userName;
                }
                else
                {
                    ViewBag.UserName = "Guest";  // Trường hợp người dùng chưa đăng nhập
                }
                return View(model);
                return View(model);
            }

        }

        // tìm một sản phẩm chi tiết
        public async Task<ActionResult> pageChiTietSanPham(int id)
        {
            string apiUrlDanhMuc = "https://localhost:5001/api/DanhMucHoa";// lấy tất cả danh mục
            string apiUrlSanPham = $"https://localhost:5001/api/Hoa/{id}"; // lấy sản phẩm qua id 

            // Tạo HttpClient để gọi API
            using (HttpClient client = new HttpClient())
            {
                // Gọi API danh mục
                HttpResponseMessage responseDanhMuc = await client.GetAsync(apiUrlDanhMuc);
                List<DanhMucHoa> danhMucData = new List<DanhMucHoa>();

                if (responseDanhMuc.IsSuccessStatusCode)
                {
                    var jsonDataDanhMuc = await responseDanhMuc.Content.ReadAsStringAsync();
                    danhMucData = JsonConvert.DeserializeObject<List<DanhMucHoa>>(jsonDataDanhMuc);
                }
                else
                {
                    ViewBag.ErrorDanhMuc = "Không thể lấy dữ liệu danh mục từ API.";
                }

                // Gọi API sản phẩm
                HttpResponseMessage responseSanPham = await client.GetAsync(apiUrlSanPham);
                Hoa sanPhamData = new Hoa();

                if (responseSanPham.IsSuccessStatusCode)
                {
                    var jsonDataSanPham = await responseSanPham.Content.ReadAsStringAsync();
                    sanPhamData = JsonConvert.DeserializeObject<Hoa>(jsonDataSanPham);
                }
                else
                {
                    ViewBag.ErrorSanPham = "Không thể lấy dữ liệu sản phẩm từ API.";
                }
                CombinedViewModel model = new CombinedViewModel
                {
                    dsDanhMuc = danhMucData,
                    chitietHoa = sanPhamData
                };
            
                return View(model);
            }
        }

        public async Task<ActionResult> pageDanhSachSanPham(int id)
        {
            string apiUrlMenu = $"https://localhost:5001/api/Hoa/HoaByID/{id}"; // Lấy danh sách món theo danh mục
            string apiUrlDanhMuc = "https://localhost:5001/api/DanhMucHoa"; // Lấy tất cả danh mục

            // Tạo HttpClient để gọi API
            using (HttpClient client = new HttpClient())
            {
                // Gọi API danh mục
                HttpResponseMessage responseDanhMuc = await client.GetAsync(apiUrlDanhMuc);//1
                List<DanhMucHoa> danhMucData = new List<DanhMucHoa>();//2

                if (responseDanhMuc.IsSuccessStatusCode)//2
                {
                    var jsonDataDanhMuc = await responseDanhMuc.Content.ReadAsStringAsync();//3 xong
                    danhMucData = JsonConvert.DeserializeObject<List<DanhMucHoa>>(jsonDataDanhMuc);
                }
                else
                {
                    ViewBag.ErrorDanhMuc = "Không thể lấy dữ liệu danh mục từ API.";
                }

                // Gọi sản phẩm by danh muc
                HttpResponseMessage responseSanPham = await client.GetAsync(apiUrlMenu);
                List<Hoa> sanPhamData = new List<Hoa>();

                if (responseSanPham.IsSuccessStatusCode)
                {
                    var jsonDataSanPham = await responseSanPham.Content.ReadAsStringAsync();
                    sanPhamData = JsonConvert.DeserializeObject<List<Hoa>>(jsonDataSanPham);
                }
                else
                {
                    ViewBag.ErrorSanPham = "Không thể lấy dữ liệu sản phẩm từ API.";
                }
                CombinedViewModel model = new CombinedViewModel
                {
                    dsDanhMuc = danhMucData,
                    dsHoaByID = sanPhamData
                };
                return View(model);
            }
        }



        public async Task<ActionResult> GioHang()
        {
           

            var userSession = Session["LoggedInUser"] as User;
            int userId;
            if (userSession != null)
            {
                 userId = userSession.userId;
                string userName = userSession.userName;
                string email = userSession.email;
                // Sử dụng các thuộc tính khác của loggedInUser theo nhu cầu
            }
            else
            {
                // Người dùng chưa đăng nhập hoặc session đã hết hạn
                return RedirectToAction("Login", "User");
            }

            string apiUrlMenu = $"https://localhost:5001/api/GioHang/{userId}"; // Lấy giỏ hàng 
            string apiUrlDanhMuc = "https://localhost:5001/api/DanhMucHoa"; // Lấy tất cả danh mục

            // Tạo HttpClient để gọi API
            using (HttpClient client = new HttpClient())
            {
                // Gọi API danh mục
                HttpResponseMessage responseDanhMuc = await client.GetAsync(apiUrlDanhMuc);
                List<DanhMucHoa> danhMucData = new List<DanhMucHoa>();

                if (responseDanhMuc.IsSuccessStatusCode)
                {
                    var jsonDataDanhMuc = await responseDanhMuc.Content.ReadAsStringAsync();
                    danhMucData = JsonConvert.DeserializeObject<List<DanhMucHoa>>(jsonDataDanhMuc);
                }
                else
                {
                    ViewBag.ErrorDanhMuc = "Không thể lấy dữ liệu danh mục từ API.";
                }

                // Gọi sản phẩm by danh muc
                HttpResponseMessage responseSanPham = await client.GetAsync(apiUrlMenu);
                List<Hoa> sanPhamData = new List<Hoa>();

                if (responseSanPham.IsSuccessStatusCode)
                {
                    var jsonDataSanPham = await responseSanPham.Content.ReadAsStringAsync();
                    sanPhamData = JsonConvert.DeserializeObject<List<Hoa>>(jsonDataSanPham);
                }
                else
                {
                    ViewBag.ErrorSanPham = "Không thể lấy dữ liệu sản phẩm từ API.";
                }
                CombinedViewModel model = new CombinedViewModel
                {
                    dsDanhMuc = danhMucData,
                    dsHoaByID = sanPhamData
                };
                return View(model);
            }
        }

     

    }
}