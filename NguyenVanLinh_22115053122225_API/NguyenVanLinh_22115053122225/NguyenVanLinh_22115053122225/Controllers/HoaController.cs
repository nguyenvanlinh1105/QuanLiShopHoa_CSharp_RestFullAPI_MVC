using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenVanLinh_22115053122225.Data;
using System.Linq;

namespace NguyenVanLinh_22115053122225.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaController : ControllerBase
    {

        public readonly WebDbContext _context;

        public HoaController(WebDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult getAllHoa()
        {
            var dsHoa = _context.hoas.ToList();
            return Ok(dsHoa);
        }

        [HttpGet("{id}")]
        public IActionResult getHoaByID(int id)
        {
            var hoa = _context.hoas.FirstOrDefault(hoa => hoa.MaH == id);
            
            if (hoa == null)
            {
                return NotFound(); 
            }

            return Ok(hoa); 
        }


        [HttpGet("HoaByID/{id}")]
        public IActionResult getAllHoaByDanhMuc(int id)
        {
            var dsHoa = _context.hoas.ToList().Where(hoa => hoa.MaDM == id);
            return Ok(dsHoa);
        }


    }
}
