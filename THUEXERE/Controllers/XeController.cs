using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using THUEXERE.ViewModel;
using WEBAPI.Data;

namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XeController : ControllerBase
    {
        private readonly WebDbContext context;
        public XeController(WebDbContext _context)
        {
            context = _context;
        }
        // function lấy ds thông tin xe 
        [HttpGet("GetDsXe")]
        public async Task<IActionResult> GetDSXe()
        {
            var dsXe = context.Xes.ToList();
            if (dsXe == null)
            {
                return NotFound("Danh sách xe bằng null");
            }
            return Ok(dsXe);

        }

        // function lấy thông tin xe theo MaXe 
        [HttpGet("GetInfoXeByMaXe")]
        public async Task<IActionResult> GetInfoXeByMaXe(string MaXe)
        {
            if (MaXe == null)
            {
                return BadRequest("Vui lòng chọn thông tin xe");
            }
            else
            {
                var findXeInfo = context.Xes.FirstOrDefault(xe => xe.MaXe == MaXe);
                if (findXeInfo == null)
                {
                    return NotFound("Không có kết quả nào được tìm thấy với MaXe=" + MaXe);
                }
                return Ok(findXeInfo);
            }

        }
        // function lấy thông tin xe theo tên xe 
        [HttpGet("GetInfoXeByTenXe")]
        public async Task<IActionResult> GetInfoXeByTenXe(string TenXe)
        {
            if (TenXe == null)
            {
                return BadRequest("Tên xe không hợp lệ");
            }
            else
            {
                var findInfoXe = context.Xes.FirstOrDefault(xe => xe.LoaiXe.loaiXe == TenXe);
                if (findInfoXe == null)
                {
                    return NotFound("Không có kết quả nào tìm thấy với tên xe =" + TenXe);
                }
                return Ok(findInfoXe);
            }
        }

        // function thêm thông tin xe
        [HttpPost("AddInfoXe")]
        public async Task<IActionResult> AddInfoXe(XeVM Xe)
        {
            if (Xe == null)
            {
                return BadRequest("Dữ liệu thông tin xe không chính xác");
            }
            else
            {
                if (Xe.IdDanhMuc == null)
                {
                    return BadRequest("Vui lòng chọn tên xe");
                }
                if (Xe.IdMauXe == null)
                {
                    return BadRequest("Vui lòng chọn màu xe");
                }
                if (Xe.IdLoaiXe == null)
                {
                    return BadRequest("Vui lòng chọn loại xe");
                }
                if (Xe.BienSo == null)
                {
                    return BadRequest("Vui lòng nhập biển số");
                }
                if (Xe.SoKhung == null)
                {
                    return BadRequest("Vui lòng nhập số khung");
                }
                string lastIdXe = context.Xes
                    .OrderByDescending(xe => xe.IdLoaiXe)
                    .Select(xe => xe.IdLoaiXe).FirstOrDefault();
                int newIdXe = 1;

                if (lastIdXe != null)
                {
                    newIdXe = int.Parse(lastIdXe.Substring(2)) + 1;

                }
                Xe newXe = new Xe();
                newXe.MaXe = Xe.MaXe;
                newXe.IdLoaiXe = Xe.IdLoaiXe;
                newXe.IdDanhMuc = Xe.IdDanhMuc;
                newXe.IdMauXe = Xe.IdMauXe;
                newXe.TinhTrang = Xe.TinhTrang;
                newXe.MoTa = Xe.MoTa;
                newXe.BienSo = Xe.BienSo;
                newXe.CongSuat = Xe.CongSuat;
                newXe.HinhAnh = Xe.HinhAnh;
                newXe.KhoiLuong = Xe.KhoiLuong;
                newXe.NamSX = Xe.NamSX;
                newXe.SoKhung = Xe.SoKhung;

                try
                {
                    context.Xes.Add(newXe);
                    await context.SaveChangesAsync();
                    return Ok(newXe);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Lỗi: " + ex.Message);
                }
            }
        }

        [HttpPut("UpdateInfoXe")]
        public async Task<IActionResult> UpdateInfoXe(XeVM XeVm)
        {
            if (XeVm == null)
            {
                return BadRequest("Dữ liệu thông tin xe không chính xác");
            }
            else
            {
                if (XeVm.IdDanhMuc == null)
                {
                    return BadRequest("Vui lòng chọn tên xe");
                }
                if (XeVm.IdMauXe == null)
                {
                    return BadRequest("Vui lòng chọn màu xe");
                }
                if (XeVm.IdLoaiXe == null)
                {
                    return BadRequest("Vui lòng chọn loại xe");
                }
                if (XeVm.BienSo == null)
                {
                    return BadRequest("Vui lòng nhập biển số");
                }
                if (XeVm.SoKhung == null)
                {
                    return BadRequest("Vui lòng nhập số khung");
                }

                var newXe = context.Xes.FirstOrDefault(x => x.MaXe == XeVm.MaXe);
                if (newXe == null)
                {
                    return NotFound("Không có thôn tin xe nào đượct ìm thấy với mã xe: " + XeVm.MaXe);
                }

                newXe.IdLoaiXe = XeVm.IdLoaiXe;
                newXe.IdDanhMuc = XeVm.IdDanhMuc;
                newXe.IdMauXe = XeVm.IdMauXe;
                newXe.TinhTrang = XeVm.TinhTrang;
                newXe.MoTa = XeVm.MoTa;
                newXe.BienSo = XeVm.BienSo;
                newXe.CongSuat = XeVm.CongSuat;
                newXe.HinhAnh = XeVm.HinhAnh;
                newXe.KhoiLuong = XeVm.KhoiLuong;
                newXe.NamSX = XeVm.NamSX;
                newXe.SoKhung = XeVm.SoKhung;

                try
                {
                    await context.SaveChangesAsync();
                    return Ok(newXe);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Lỗi: " + ex.Message);
                }
            }
        }
    }

}
