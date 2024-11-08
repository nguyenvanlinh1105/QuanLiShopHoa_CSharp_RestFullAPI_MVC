using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenVanLinh_22115053122225.Data;

namespace NguyenVanLinh_22115053122225.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {

        public readonly WebDbContext _context;
        public GioHangController(WebDbContext context)
        {
            this._context = context;

        }
        [HttpGet("{id}")]
        public IActionResult getGioHang(int id)
        {
            // Lấy giỏ hàng cùng với các thiết bị liên quan
            var gioHang = _context.hoas.ToList().Where(sp => sp.MaGioHang == id);

            return Ok(gioHang); 
        }

    }
}
