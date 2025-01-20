using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using THUEXERE.ViewModel;
using WEBAPI.Data;

namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonThueController : ControllerBase
    {
        private readonly WebDbContext context;
        public ChiTietDonThueController(WebDbContext context)
        {
            this.context = context;
        }

        // function lấy ds chi tiết đơn thuê 
        [HttpGet("GetDsChiTietDonThue")]
        public async Task<IActionResult> GetDsChiTietDonThue()
        {
            var dsChiTietDonThue = context.chiTietDonThues.ToList();
            if (dsChiTietDonThue == null)
            {
                return NotFound("Danh sách chi tiết đơn thuê rỗng");
            }
            return Ok(dsChiTietDonThue);
        }

        // function lấy ds chi tiết đơn huê theo mã đơn thuê 
        [HttpGet("GetDsDonThueByMaDT")]
        public async Task<IActionResult> GetDsDonThueByMaDT(string MaDT)
        {
            if(MaDT == null)
            {
                return StatusCode(400, "Dữ liệu mã đơn thuê không hợp lệ");
            }

            var dsChiTietDonThue = context.chiTietDonThues.Where(dt => dt.MaDT == MaDT).ToList();
            if (dsChiTietDonThue == null)
            {
                return NotFound("Không có đơn thuê nào của mã đơn thuê =" + MaDT);
            }
            return Ok(dsChiTietDonThue);
        }
        // function lấy chi tiết đơn thuê theo mã chi tiết đơn thuê 
        [HttpGet("GetChiTietDonThueByMaCTDT")]
        public async Task<IActionResult> GetChiTietDonThueByMaCTDT(string MaCTDT)
        {
            if (MaCTDT == null)
            {
                return StatusCode(400, "Dữ liệu mã chi tiết đơn thuê không hợp lệ");
            }

            var chiTietDonThue = context.chiTietDonThues.FirstOrDefault(dt => dt.MaCTDT == MaCTDT);
            if(chiTietDonThue == null)
            {
                return NotFound($"không có đơn thuê nào được tìm thấy với mã = {MaCTDT}");
            }
            return Ok(chiTietDonThue);
        }


        // function update thông tin chi tiết đơn thuê 
        [HttpPut("UpdateInfoChiTietDonThue")]
        public async Task<IActionResult> UpdateInfoChiTietDonThue(ChiTietDonThueVM chiTietDonThueVM)
        {
            if (chiTietDonThueVM == null)
            {
                return StatusCode(400, "Dữ liệu chi tiết đơn thuê không hợp lệ!");
            }
            if(chiTietDonThueVM.MaCTDT == null)
            {
                return StatusCode(400, "Mã chi tiết đơn thuê không hợp lệ!");
            }

            var findChiTietDonThue = context.chiTietDonThues.FirstOrDefault(ctdt => ctdt.MaCTDT == chiTietDonThueVM.MaCTDT);
            if (findChiTietDonThue == null)
            {
                return NotFound("Không tìm thấy đơn thuê theo mã đơn thuê = " + chiTietDonThueVM.MaCTDT);
            }
            findChiTietDonThue.MaXe = chiTietDonThueVM.MaXe;
            findChiTietDonThue.NgayNhan= chiTietDonThueVM.NgayNhan;
            findChiTietDonThue.NgayTra= chiTietDonThueVM.NgayTra;
            findChiTietDonThue.TienCocGuiXe = chiTietDonThueVM.TienCocGuiXe;
            findChiTietDonThue.TienCocXe = chiTietDonThueVM.TienCocXe;
            findChiTietDonThue.ThanhTien = chiTietDonThueVM.ThanhTien;
            findChiTietDonThue.TrangThai = chiTietDonThueVM.TrangThai;
            findChiTietDonThue.PTThanhToan = chiTietDonThueVM.PTThanhToan;
            findChiTietDonThue.TinhTrangBanGiao = chiTietDonThueVM.TinhTrangBanGiao;
            findChiTietDonThue.NoiNhan = chiTietDonThueVM.NoiNhan;
            findChiTietDonThue.NoiTra = chiTietDonThueVM.NoiTra;
            if (chiTietDonThueVM.GiaHan != null&&chiTietDonThueVM.NgayGiaHan!=null)
            {
                findChiTietDonThue.GiaHan = chiTietDonThueVM.GiaHan;
                findChiTietDonThue.NgayGiaHan = chiTietDonThueVM.NgayGiaHan;

            }
            return Ok(findChiTietDonThue);
        }


    }
}
