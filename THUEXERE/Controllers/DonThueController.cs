using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THUEXERE.ViewModel;
using WEBAPI.Data;

namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonThueController : ControllerBase
    {
        private readonly WebDbContext context;

        public DonThueController(WebDbContext context) {
            this.context = context;
        }
        // function lấy ds đơn thuê 
        [HttpGet("GetDsDonThue")]
        public async Task<IActionResult> GetDsDonThue()
        {
            var dsDonThue = context.DonThues.ToList();
            if (dsDonThue == null)
            {
                return NotFound("Danh sách đơn thuê trống");
            }
            return Ok(dsDonThue);
        }

       

        // update đon thuê 
        [HttpPut("UpdateInfoDonThue")]
        public async Task<IActionResult> UpdateInfoDonThue(DonThueVM donThueVM)
        {
            if(donThueVM == null)
            {
                return StatusCode(400, "Dữ liệu đơn thuê không hợp lệ");
            }
            if(donThueVM.MaDT == null)
            {
                return StatusCode(400, "Mã đơn thuê không được phép null");
            }
            var findDonThue = context.DonThues.FirstOrDefault(dt=>dt.MaDT==donThueVM.MaDT);
            if(findDonThue == null)
            {
                return NotFound("Không có đơn thuê nào được tìm thấy với mã đơn thuê " + donThueVM.MaDT);
            }
            findDonThue.PTThanhToan = donThueVM.PTThanhToan;
            findDonThue.TinhTrangDon = donThueVM.TinhTrangDon;
            findDonThue.TongTien = donThueVM.TongTien;

            try
            {
                await context.SaveChangesAsync();
                return Ok(findDonThue);
            }
            catch (Exception ex) { 
                return StatusCode(500,"Lỗi"+ex.Message);
            }
        }


        // TẠO MỚI ĐƠN THUÊ - LOGIC XỬ lÍ CHI TIẾT ĐƠN THUÊ 
        [HttpPost("AddInfoDonThue")]
        public async Task<IActionResult> AddInfoDonThue(DonThueVM donThueVM)
        {
            if (donThueVM == null)
            {
                return StatusCode(400, "Dữ liệu đơn thuê không hợp lệ");
            }
            if (donThueVM.MaKH == null || donThueVM.PTThanhToan == null||donThueVM.chiTietDonThues==null)
            {
                return StatusCode(400, $"Dữ liệu mã khách hàng = {donThueVM.MaKH} hoặc phương thức thanh toán= {donThueVM.PTThanhToan} dữ liệu chi tiết đơn thuê không hợp lệ");
            }

            string lastIdDonThue = context.DonThues.OrderByDescending(dt => dt.MaDT).Select(dt => dt.MaDT).FirstOrDefault();
            int newIdNumberDonThue = 1;
            if (lastIdDonThue != null)
            {
                newIdNumberDonThue = int.Parse(lastIdDonThue.Substring(2)) + 1;
            }

            DonThue newDonThue = new DonThue();
            newDonThue.MaDT = $"DT{newIdNumberDonThue:D5}";
            newDonThue.MaKH = donThueVM.MaKH;
            newDonThue.MaNVHT = null;
            newDonThue.PTThanhToan = donThueVM.PTThanhToan;
            newDonThue.TongTien = donThueVM.TongTien;
            newDonThue.TinhTrangDon = "Chưa hoàn thành";
            newDonThue.NgayTao = donThueVM.NgayTao;

            try
            {
                context.DonThues.Add(newDonThue);
                int result = await context.SaveChangesAsync();
  
                if (result > 0)
                {
                    int count = 0;
                    int newIdNumberCTDT = 1;
                    List<ChiTietDonThue> listChiTietDonThue = new List<ChiTietDonThue>();
                    // check info của chi tiết đơn thuê 
                    foreach (ChiTietDonThueVM ctdt in donThueVM.chiTietDonThues) {
                        if (ctdt.MaXe == null || ctdt.PTThanhToan == null||ctdt.TinhTrangBanGiao==null||ctdt.NoiTra==null||ctdt.NoiNhan==null)
                        {
                            return StatusCode(400, $"Dữ liệu chi tiết đơn thuê thứ {count} không hợp lệ");
                        }
                        // tạo id chi tiết đơn thuê tiếp theo 
                        string lastIdCTDT = context.chiTietDonThues.OrderByDescending( ct => ct.MaCTDT)
                            .Select(ct => ct.MaCTDT ).FirstOrDefault();

                        if (lastIdCTDT != null)
                        {
                            newIdNumberCTDT = int.Parse(lastIdCTDT.Substring(4)) + 1;
                        }
                       
                        ChiTietDonThue newDT= new ChiTietDonThue();
                        newDT.MaCTDT = $"CTDT{newIdNumberCTDT:D3}";
                        newDT.MaDT = newDonThue.MaDT;
                        newDT.MaXe = ctdt.MaXe;
                        newDT.NgayNhan = ctdt.NgayNhan;
                        newDT.NgayTra = ctdt.NgayTra;
                        newDT.TienCocGuiXe = ctdt.TienCocGuiXe;
                        newDT.TienCocXe = ctdt.TienCocXe;
                        newDT.ThanhTien = ctdt.ThanhTien;
                        newDT.TrangThai = ctdt.TrangThai;
                        newDT.PTThanhToan = ctdt.PTThanhToan;
                        newDT.TinhTrangBanGiao = ctdt.TinhTrangBanGiao;
                        newDT.NoiNhan = ctdt.NoiNhan;
                        newDT.NoiTra = ctdt.NoiTra;
                        if (ctdt.GiaHan != null && ctdt.NgayGiaHan != null)
                        {
                            newDT.GiaHan = ctdt.GiaHan;
                            newDT.NgayGiaHan = ctdt.NgayGiaHan;

                        }
                        listChiTietDonThue.Add(newDT);

                        count++;
                    }

                    try
                    {
                        await context.chiTietDonThues.AddRangeAsync(listChiTietDonThue);
                        int check = await context.SaveChangesAsync();
                        if (check > 0) {
                            //var resultDonThue = context.DonThues.Where(dt => dt.MaDT == $"DT{newIdNumberDonThue:D5}");
                            //if (resultDonThue != null)
                            //{
                            //    return Ok(resultDonThue);
                            //}
                              return Ok($"Tạo đơn thuê thành công với mã đơn thuê DT{newIdNumberDonThue:D5}");
                        }

                    }
                    catch(Exception ex)
                    {
                        return StatusCode(500,"Lỗi: "+ex.Message);
                    }

                    return Ok("Thêm mới thành công!");
                }
                else
                {
                    return StatusCode(500, "Lỗi khi thêm mới");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi : " + ex.Message);
            }
        }
    }
}
