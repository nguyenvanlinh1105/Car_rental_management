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
    public class MauXeController : ControllerBase
    {
        private readonly WebDbContext context;
        public MauXeController(WebDbContext _context)
        {
            this.context = _context;
        }
        // function get ds màu xe 
        [HttpGet("GetDsMauXe")]
        public async Task<IActionResult> GetDsMauXe()
        {
            var dsMauXe = context.MauXes.ToList();
            if(dsMauXe.Count == 0) { return NotFound(); }
            var result = dsMauXe.Select(mx => new
            {
                IdMauXe = mx.IdMauXe,
                mauXe = mx.mauXe
            });
            return Ok(dsMauXe);
        }
        [HttpPost("AddMauXe")]
        public async Task<IActionResult> AddMauXe(MauXeVM mauXe)
        {
            if(mauXe == null) { return BadRequest("Thông tin dữ liệu màu xe không hợp lệ"); }
            if (mauXe.mauXe == null) { return BadRequest("Vui lòng nhập tên màu xe"); }
            else
            {
                try
                {
                    string lastIdMauXe = context.MauXes.OrderByDescending(mx => mx.IdMauXe)
                        .Select(mx => mx.IdMauXe).FirstOrDefault();
                    int newIdMauXeNumber = 1;
                    if (lastIdMauXe != null)
                    {
                        newIdMauXeNumber = int.Parse(lastIdMauXe.Substring(2)) + 1;
                    }
                    MauXe newMauXe = new MauXe();
                    newMauXe.IdMauXe = $"MX{newIdMauXeNumber:D5}";
                    newMauXe.mauXe = mauXe.mauXe;
                    context.MauXes.Add(newMauXe);
                    await context.SaveChangesAsync();
                    return Ok(newMauXe);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
                return Ok();
            }
        }
        [HttpPut("UpdateInfoMauXe")]
        public async Task<IActionResult> UpdateInfoMauXe(MauXeVM mauXe)
        {
            if (mauXe == null)
            {
                return BadRequest("Dữ liệu của mau xe không chính xác");
            }
            else
            {
                MauXe findMauXe = context.MauXes.FirstOrDefault(mx => mx.IdMauXe == mauXe.IdMauXe);
                if (findMauXe == null)
                {
                    return NotFound("Không tìm thấy màu xe với Id=" + mauXe.IdMauXe);
                }
                else
                {
                    findMauXe.mauXe = mauXe.mauXe;
                    try { 
                        await context.SaveChangesAsync();
                        return Ok(findMauXe);
                    }catch(Exception ex)
                    {
                        Console.WriteLine("Lỗi: "+ex.Message);
                    }
                }
            }
            return Ok();
        }
    }
}
