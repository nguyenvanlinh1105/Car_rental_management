using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Data;

namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly WebDbContext context;
        public BaiVietController(WebDbContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetDsBaiViet()
        {
            var dsBaiViet = context.BaiViets.ToList();
            return Ok(dsBaiViet);
        }
    }
}
