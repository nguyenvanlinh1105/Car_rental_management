using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Data;

namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GopYController : ControllerBase
    {
        private readonly WebDbContext context;
        public  GopYController(WebDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDsGopY()
        {
            var dsGopY  = context.GopYs.ToList();
            return Ok(dsGopY);
        }
    }
}
