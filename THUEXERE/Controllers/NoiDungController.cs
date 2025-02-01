using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Data;

namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoiDungController : ControllerBase
    {
        private readonly WebDbContext context;
        public NoiDungController(WebDbContext context) { 
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDsNoiDung()
        {
            var dsNoiDung = context.NoiDungs.ToList();
            return Ok(dsNoiDung);

        }
    }
}
