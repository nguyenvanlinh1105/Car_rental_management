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
    public class DichVuController : ControllerBase
    {
        private readonly WebDbContext context;
        public DichVuController(WebDbContext _context) {
            this.context = _context;
        }
        // function lấy danh sách dịch vụ
        [HttpGet("GetDsDichVu")]
        public async Task<IActionResult> GetDsDichVu()
        {
            var dsDichVu = context.DichVus.ToList();
            if (dsDichVu == null)
            {
                return NotFound("Không có dịch vụ nào !");
            }
            return Ok(dsDichVu);
        }
        // function lấy dịch vụ theo id 
        [HttpGet("FindDichVuByMaDichVu")]
        public async Task<IActionResult> FindDichVuByMaDichVu(string MaDichVu)
        {
            if (MaDichVu == null) {
                return StatusCode(400, "Mã dịch vụ không hợp lệ");
            }
            var findDichVu = context.DichVus.FirstOrDefault(dv => dv.MaDV == MaDichVu);
            if (findDichVu == null) {
                return NotFound("Không có dịch vụ nào tìm thấy với mã dịch vụ:" + MaDichVu);
            }
            return Ok(findDichVu);

        }

        // function lấy dịch vụ theo khoảng giá 
        [HttpGet("FindDichVuFromToPrice")]
        public async Task<IActionResult> FindDichVuFromToPrice(double? fromPrice, double? toPrice)
        {
            // Kiểm tra khoảng giá hợp lệ
            if (fromPrice == null || toPrice == null || fromPrice > toPrice)
            {
                return StatusCode(400, "Vui lòng chọn khoảng giá hợp lệ");
            }

            // Lấy danh sách dịch vụ trong khoảng giá
            var findDichVus = context.DichVus
                .Where(dv => (double)dv.DonGia >= fromPrice && (double)dv.DonGia <= toPrice)
                .ToList();

            // Kiểm tra nếu không có kết quả
            if (!findDichVus.Any())
            {
                return NotFound("Không có kết quả nào được tìm thấy");
            }

            return Ok(findDichVus);
        }

        //thêm dịch vụ 
        [HttpPost("AddInfoDichVu")]
        public async Task<IActionResult> AddInfoDichVu(DichVuVM dichVu)
        {
            if (dichVu == null)
            {
                return StatusCode(400, "Dữ liệu dịch vụ không hợp lệ");
            }
            else
            {
                if (dichVu.TenDV == null || dichVu.DonGia == null || dichVu.DonGia <= 0)
                {
                    return StatusCode(400, "Vui lòng nhập tên và giá hợp lệ");
                }
                else
                {
                    string lastIdDichVu = context.DichVus
                        .OrderByDescending(dv => dv.MaDV)
                        .Select(dv => dv.MaDV).FirstOrDefault();
                    int newIdDichVuNumber = 1;
                    if (lastIdDichVu != null)
                    {
                        newIdDichVuNumber = int.Parse(lastIdDichVu.Substring(2)) + 1;
                    }
                    DichVu newDichVu = new DichVu();
                    newDichVu.MaDV = $"DV{newIdDichVuNumber:D5}";
                    newDichVu.TenDV = dichVu.TenDV;
                    newDichVu.MoTa = dichVu.MoTa;
                    newDichVu.AnhMinhHoaUrl = dichVu.AnhMinhHoaUrl;
                    newDichVu.TinhTrang = dichVu.TinhTrang;
                    newDichVu.DonGia = dichVu.DonGia;
                    newDichVu.SoLuong = dichVu.SoLuong;
                    newDichVu.HinhThuc = dichVu.HinhThuc;
                    newDichVu.DonVi = dichVu.DonVi;
                    newDichVu.Loai = dichVu.Loai;

                    try
                    {
                        context.DichVus.Add(newDichVu);
                        await context.SaveChangesAsync();
                        return Ok(newDichVu);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, "Lỗi:" + ex.Message);
                    }
                }
            }
            /*
             * test :
             *       {
                      "tenDV": "Dịch vụ vệ sinh nhà cửa",
                      "anhMinhHoaUrl": "https://example.com/images/dich-vu-ve-sinh.jpg",
                      "moTa": "Dịch vụ vệ sinh nhà cửa chuyên nghiệp, nhanh chóng và sạch sẽ.",
                      "tinhTrang": "Còn hoạt động",
                      "donGia": 500000,
                      "soLuong": 1,
                      "hinhThuc": "Gói dịch vụ",
                      "donVi": "Lần",
                      "loai": "Vệ sinh"
                    }
             */



           
           
        
        }

        // hàm update thông tin 
        [HttpPut("UpdateInfoDichVu")]
        public async Task<IActionResult> UpdateInfoDichVu(DichVuVM dichVu)
        {
            if (dichVu == null)
            {
                return StatusCode(400, "Dữ liệu dịch vụ cập nhật không hợp lệ");
            }
            else
            {
                if (dichVu.MaDV == null)
                {
                    return StatusCode(400, "Dữ liệu mã dịch vụ cập nhật không hợp lệ");
                }
                //lấy dịch vụ theo mã dịch vụ
                var findDichVu = context.DichVus.FirstOrDefault(dv => dv.MaDV == dichVu.MaDV);

                if (findDichVu == null)
                {
                    return StatusCode(400, "Không có kết quả nào được tìm thấy với mã dichVu: "+dichVu.MaDV);
                }
                findDichVu.TenDV = dichVu.TenDV;
                findDichVu.MoTa = dichVu.MoTa;
                findDichVu.AnhMinhHoaUrl = dichVu.AnhMinhHoaUrl;
                findDichVu.TinhTrang = dichVu.TinhTrang;
                findDichVu.DonGia = dichVu.DonGia;
                findDichVu.SoLuong = dichVu.SoLuong;
                findDichVu.HinhThuc = dichVu.HinhThuc;
                findDichVu.DonVi = dichVu.DonVi;
                findDichVu.Loai = dichVu.Loai;
                try
                {
                   await context.SaveChangesAsync();
                    return Ok(findDichVu);
                }catch(Exception ex)
                {
                    return StatusCode(500, "Lỗi: " + ex.Message);
                }
            }
        }

        // hàm cập nhật trạng thái hoạt động dịch vụ 
        [HttpPut("UpdatTrangThaiHoatDongDichVu")]
        public async Task<IActionResult> UpdatTrangThaiHoatDongDichVu(DichVuVM dichVuVM)
        {
            if (dichVuVM == null)
            {
                return StatusCode(400, "Dữ liệu dịch vụ không hợp lệ");
            }
            if (dichVuVM.MaDV == null||dichVuVM.TinhTrang==null)
            {
                return StatusCode(400, $"Dữ liệu Mã dịch vụ ={dichVuVM.MaDV} hoặc tình trạng={dichVuVM.TinhTrang} không hợp lệ");
            }
            var findDichVu = context.DichVus.FirstOrDefault(dv => dv.MaDV == dichVuVM.MaDV);
            if (findDichVu == null)
            {
                return StatusCode(400, $"Không có dịch vụ nào tìm thấy với mã dịch vu={dichVuVM.MaDV}");
            }
            findDichVu.TinhTrang = dichVuVM.TinhTrang;
            try
            {
                await context.SaveChangesAsync();
                return Ok(findDichVu);
            }catch(Exception ex)
            {
                return StatusCode(500, "Lỗi: " + ex.Message);
            }
        }





    }
}
