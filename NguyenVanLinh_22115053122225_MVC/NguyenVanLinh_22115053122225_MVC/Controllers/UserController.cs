using Newtonsoft.Json;
using NguyenVanLinh_22115053122225_MVC.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NguyenVanLinh_22115053122225_MVC.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Login([Bind(Include = "userName,password")] User user)
        {
            System.Console.WriteLine(user.password + user.userName);

            string apiUrl = "https://localhost:5001/api/User/Login";

            using (HttpClient client = new HttpClient())
            {
                var loginData = new 
                {
                    userName = user.userName,
                    password = user.password
                };


                var json = JsonConvert.SerializeObject(loginData);



                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var userloginResponse = JsonConvert.DeserializeObject<User>(responseData);
                    Session["LoggedInUser"] = userloginResponse;
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    ViewBag.ErrorMessage = "Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin đăng nhập.";
                    return View("Login");
                }
            }
        }


        // Action method hiển thị trang đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
