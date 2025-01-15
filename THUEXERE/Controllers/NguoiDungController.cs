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
    public class NguoiDungController : ControllerBase
    {
        private readonly WebDbContext context; 
        public NguoiDungController(WebDbContext _context) { 
            context = _context;
        }

        // lấy ds Người dùng
        [HttpGet("GetDsNguoiDung")]
        public async Task<IActionResult> GetDsNguoiDung()
        {
            var dsNguoiDung= context.NguoiDungs.ToList();
            if (dsNguoiDung == null)
            {
                return NotFound("Không tìm thấy người dùng nào!");
            }
            return Ok(dsNguoiDung);
        }
        // thêm người dùng
        [HttpPost("AddInfoNguoiDung")]
        public async Task<IActionResult> AddInfoNguoiDung(NguoiDungVM NguoiDung)
        {
            int newIdNguoiDungNumber = 1; 
            if (NguoiDung == null)
            {
                return BadRequest("Dữ liệu người dùng không chính xác");
            }
            else
            {
                if (NguoiDung.HoTen == null || NguoiDung.Email == null|| NguoiDung.MatKhau == null || NguoiDung.GioiTinh == null)
                {
                    return BadRequest("Vui lòng nhập đủ họ tên, email, mật khẩu, ngày sinh, giới tính");
                }
                if (NguoiDung.typeNguoiDung == "Admin")
                {
                    string lastIdAdmin  = context.NguoiDungs.Where(nd=>nd.MaND.StartsWith("AD")).OrderByDescending(nd=>nd.MaND)
                        .Select(nd=>nd.MaND)
                        .FirstOrDefault();
                    if (lastIdAdmin != null) {
                        newIdNguoiDungNumber = int.Parse(lastIdAdmin.Substring(2))+1;
                    }
                    NguoiDung newNguoiDung = new NguoiDung();
                    newNguoiDung.MaND = $"AD{newIdNguoiDungNumber:D5}";
                    newNguoiDung.HoTen = NguoiDung.HoTen;
                    newNguoiDung.NgaySinh = NguoiDung.NgaySinh;
                    newNguoiDung.Email = NguoiDung.Email;
                    newNguoiDung.SDT = NguoiDung.SDT;
                    newNguoiDung.CCCD = NguoiDung.CCCD;
                    newNguoiDung.GioiTinh = NguoiDung.GioiTinh;
                    newNguoiDung.DiaChi = NguoiDung.DiaChi;
                    newNguoiDung.TinhTrang = NguoiDung.TinhTrang;
                    newNguoiDung.MatKhau = NguoiDung.MatKhau;
                    newNguoiDung.AnhDaiDienUrl = NguoiDung.AnhDaiDienUrl;
                    newNguoiDung.NgayTao = DateTime.Now;
                    newNguoiDung.NgayCapNhat = null;
                    try
                    {
                        context.NguoiDungs.Add(newNguoiDung);
                        await context.SaveChangesAsync();
                        return Ok(newNguoiDung);
                    }
                    catch (Exception ex) { 
                        return StatusCode(500,"Lỗi: "+ ex.Message);
                    }
                }
                else if(NguoiDung.typeNguoiDung=="KhachHang")
                {
                    string lastIdAdmin = context.NguoiDungs.Where(nd => nd.MaND.StartsWith("KH")).OrderByDescending(nd => nd.MaND)
                       .Select(nd => nd.MaND)
                       .FirstOrDefault();
                    if (lastIdAdmin != null)
                    {
                        newIdNguoiDungNumber = int.Parse(lastIdAdmin.Substring(2)) + 1;
                    }
                    NguoiDung newNguoiDung = new NguoiDung();
                    newNguoiDung.MaND = $"KH{newIdNguoiDungNumber:D5}";
                    newNguoiDung.HoTen = NguoiDung.HoTen;
                    newNguoiDung.NgaySinh = NguoiDung.NgaySinh;
                    newNguoiDung.Email = NguoiDung.Email;
                    newNguoiDung.SDT = NguoiDung.SDT;
                    newNguoiDung.CCCD = NguoiDung.CCCD;
                    newNguoiDung.GioiTinh = NguoiDung.GioiTinh;
                    newNguoiDung.DiaChi = NguoiDung.DiaChi;
                    newNguoiDung.TinhTrang = NguoiDung.TinhTrang;
                    newNguoiDung.MatKhau = NguoiDung.MatKhau;
                    newNguoiDung.AnhDaiDienUrl = NguoiDung.AnhDaiDienUrl;
                    newNguoiDung.NgayTao = DateTime.Now;
                    newNguoiDung.NgayCapNhat = null;
                    try
                    {
                        context.NguoiDungs.Add(newNguoiDung);
                        await context.SaveChangesAsync();
                        return Ok(newNguoiDung);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, "Lỗi: " + ex.Message);
                    }
                }
                else if (NguoiDung.typeNguoiDung == "HoTro")
                {
                    string lastIdAdmin = context.NguoiDungs.Where(nd => nd.MaND.StartsWith("HT")).OrderByDescending(nd => nd.MaND)
                       .Select(nd => nd.MaND)
                       .FirstOrDefault();
                    if (lastIdAdmin != null)
                    {
                        newIdNguoiDungNumber = int.Parse(lastIdAdmin.Substring(2)) + 1;
                    }
                    NguoiDung newNguoiDung = new NguoiDung();
                    newNguoiDung.MaND = $"HT{newIdNguoiDungNumber:D5}";
                    newNguoiDung.HoTen = NguoiDung.HoTen;
                    newNguoiDung.NgaySinh = NguoiDung.NgaySinh;
                    newNguoiDung.Email = NguoiDung.Email;
                    newNguoiDung.SDT = NguoiDung.SDT;
                    newNguoiDung.CCCD = NguoiDung.CCCD;
                    newNguoiDung.GioiTinh = NguoiDung.GioiTinh;
                    newNguoiDung.DiaChi = NguoiDung.DiaChi;
                    newNguoiDung.TinhTrang = NguoiDung.TinhTrang;
                    newNguoiDung.MatKhau = NguoiDung.MatKhau;
                    newNguoiDung.AnhDaiDienUrl = NguoiDung.AnhDaiDienUrl;
                    newNguoiDung.NgayTao = DateTime.Now;
                    newNguoiDung.NgayCapNhat = null;
                    try
                    {
                        context.NguoiDungs.Add(newNguoiDung);
                        await context.SaveChangesAsync();
                        return Ok(newNguoiDung);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, "Lỗi: " + ex.Message);
                    }
                }
                else if (NguoiDung.typeNguoiDung == "QuanLi")
                {
                    string lastIdAdmin = context.NguoiDungs.Where(nd => nd.MaND.StartsWith("QL")).OrderByDescending(nd => nd.MaND)
                       .Select(nd => nd.MaND)
                       .FirstOrDefault();
                    if (lastIdAdmin != null)
                    {
                        newIdNguoiDungNumber = int.Parse(lastIdAdmin.Substring(2)) + 1;
                    }
                    NguoiDung newNguoiDung = new NguoiDung();
                    newNguoiDung.MaND = $"QL{newIdNguoiDungNumber:D5}";
                    newNguoiDung.HoTen = NguoiDung.HoTen;
                    newNguoiDung.NgaySinh = NguoiDung.NgaySinh;
                    newNguoiDung.Email = NguoiDung.Email;
                    newNguoiDung.SDT = NguoiDung.SDT;
                    newNguoiDung.CCCD = NguoiDung.CCCD;
                    newNguoiDung.GioiTinh = NguoiDung.GioiTinh;
                    newNguoiDung.DiaChi = NguoiDung.DiaChi;
                    newNguoiDung.TinhTrang = NguoiDung.TinhTrang;
                    newNguoiDung.MatKhau = NguoiDung.MatKhau;
                    newNguoiDung.AnhDaiDienUrl = NguoiDung.AnhDaiDienUrl;
                    newNguoiDung.NgayTao = DateTime.Now;
                    newNguoiDung.NgayCapNhat = null;
                    try
                    {
                        context.NguoiDungs.Add(newNguoiDung);
                        await context.SaveChangesAsync();
                        return Ok(newNguoiDung);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, "Lỗi: " + ex.Message);
                    }
                }
                return Ok();
            }

        }

        // cập nhật thông tin người dùng
        [HttpPut("UpdateInfoNguoiDung")]
        public async Task<IActionResult> UpdateInfoNguoiDung(NguoiDungVM NguoiDung)
        {
            if (NguoiDung == null)
            {
                return BadRequest("Dữ liệu người dung cập nhật không chính xác");
            }
            else
            {
                var findNguoiDung = context.NguoiDungs.FirstOrDefault(nd=>nd.MaND== NguoiDung.MaND);
                if(findNguoiDung == null)
                {
                    return BadRequest("Không có người dùng nào được tìm thấy với mã người dùng: " + NguoiDung.MaND);
                }
                findNguoiDung.HoTen = NguoiDung.HoTen;
                findNguoiDung.NgaySinh = NguoiDung.NgaySinh;
                findNguoiDung.Email = NguoiDung.Email;
                findNguoiDung.SDT = NguoiDung.SDT;
                findNguoiDung.CCCD = NguoiDung.CCCD;
                findNguoiDung.GioiTinh = NguoiDung.GioiTinh;
                findNguoiDung.DiaChi = NguoiDung.DiaChi;
                findNguoiDung.TinhTrang = NguoiDung.TinhTrang;
                findNguoiDung.MatKhau = NguoiDung.MatKhau;
                findNguoiDung.AnhDaiDienUrl = NguoiDung.AnhDaiDienUrl;
               // findNguoiDung.NgayCapNhat = DateTime.Today;

                try
                {
                    await context.SaveChangesAsync();
                    return Ok(findNguoiDung);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Lỗi: " + ex.Message);
                }
            }
        }
        

    }
}
