using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenVanLinh_22115053122225.Data;

namespace NguyenVanLinh_22115053122225.Controllers
{

    public class LoginRequest
{
    public string userName { get; set; }
    public string password { get; set; }
}

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly WebDbContext _context;
        public UserController(WebDbContext context)
        {
            this._context = context;

        }

        [HttpGet]
        public IActionResult Login()
        {
            var users = _context.users.ToList();
            return Ok(users);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            System.Console.WriteLine(request.password+request.userName);
            // Kiểm tra tính hợp lệ của UserName và Password
            var user = _context.users
                .FirstOrDefault(u => u.userName == request.userName && u.password == request.password);

            if (user != null)
            {
                // Nếu đăng nhập thành công, trả về thông tin người dùng
                return Ok(new
                {
                    UserId = user.userId,
                    UserName = user.userName,
                    Email = user.email
                });
            }
            else
            {
                // Nếu thông tin đăng nhập không chính xác, trả về 401 Unauthorized
                return Unauthorized("Invalid username or password.");
            }
        }

    }
}
