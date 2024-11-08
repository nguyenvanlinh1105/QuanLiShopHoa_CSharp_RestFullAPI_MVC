using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenVanLinh_22115053122225.Data;
using System.Linq;

namespace NguyenVanLinh_22115053122225.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucHoaController : ControllerBase
    {
        public readonly WebDbContext _context;

        public DanhMucHoaController(WebDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult getAllHoa()
        {
            var dsDanhMuc = _context.danhMucHoas.ToList();
            return Ok(dsDanhMuc);
        }
    }
}
