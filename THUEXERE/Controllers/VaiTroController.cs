using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using THUEXERE.ViewModel;
using WEBAPI.Data;

namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaiTroController : ControllerBase
    {
        private readonly WebDbContext context;
        public VaiTroController(WebDbContext _context) { 
            this.context = _context;
        }
        // function get ds vai trò người dùng 
        [HttpGet("GetDsVaiTroNguoiDung")]
        public async Task<IActionResult> GetDsVaiTro()
        {
            var dsVaiTro = context.VaiTros.ToList();
            if (dsVaiTro == null)
            {
                return NotFound("Danh sách vai trò trống");
            }
            return Ok(dsVaiTro);
        }

        // thêm vai trò người dùng 
        [HttpPost("AddVaiTroNguoiDung")]
        public async Task<IActionResult> AddVaiTroNguoiDung(VaiTroVM vaiTroVM)
        {
            if(vaiTroVM == null)
            {
                return StatusCode(400,"Dữ liệu người dùng không hợp lệ");
            }
            if (vaiTroVM.TenVT == null)
            {
                return StatusCode(400, "Tên của vai trò không được để trống");
            }
            string lastIdVaiTro = context.VaiTros.OrderByDescending(vt=>vt.MaVT)
                .Select(vt=>vt.MaVT).FirstOrDefault();
            int newIdVaiTroNumber = 1;
            if (lastIdVaiTro != null)
            {
                newIdVaiTroNumber = int.Parse(lastIdVaiTro.Substring(2))+1;
            }

            VaiTro newVaiTro = new VaiTro();
            newVaiTro.MoTa = $"VT{newIdVaiTroNumber:D5}";
            newVaiTro.TenVT = vaiTroVM.TenVT;
            newVaiTro.MoTa = vaiTroVM.MoTa;

            try
            {
                context.VaiTros.Add(newVaiTro);
                await context.SaveChangesAsync();
                return Ok(newVaiTro);
            }catch(Exception ex)
            {
                return StatusCode(500,"Lỗi: "+ex.Message);
            }
        }

        // function update vai trò người dùng 
        [HttpPut("UpdateINfoVaiTroNguoidung")]
        public async Task<IActionResult> UpdateINfoVaiTroNguoidung(VaiTroVM vaiTroVM)
        {
            if(vaiTroVM == null)
            {
                return StatusCode(400, "Dữ liệu vai trò người dùng không hợp lệ");
            }
            else
            {
                if(vaiTroVM.MaVT == null)
                {
                    return StatusCode(400, "Mã vai trò người dùng không hợp lệ");
                }
                var findVaiTro = context.VaiTros.FirstOrDefault(vt => vt.MaVT==vaiTroVM.MaVT);
                if(findVaiTro == null)
                {
                    return StatusCode(400, "Không có vài trò nào được tìm thấy với mã vai trò " + vaiTroVM.MaVT);
                }

                findVaiTro.TenVT = vaiTroVM.TenVT;
                findVaiTro.MoTa = vaiTroVM.MoTa;
                try
                {
                    await context.SaveChangesAsync();
                    return Ok(findVaiTro);
                }catch(Exception ex)
                {
                    return StatusCode(500, "Lỗi: " + ex.Message);
                }
            }
        }
    }
}
