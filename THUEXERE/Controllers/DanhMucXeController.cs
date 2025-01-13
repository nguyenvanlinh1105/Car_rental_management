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
    public class DanhMucXeController : ControllerBase
    {
        private readonly WebDbContext context; 
       public DanhMucXeController(WebDbContext _context) {
            this.context = _context;
        }

        // function get danh mục tên xe 
        [HttpGet("GetDsDanhMucXe")]
        public async Task<IActionResult> GetDSDanhMucXe()
        {
            var dsDanhMuc = context.DanhMucXes.ToList();
            if(dsDanhMuc == null)
            {
                return NotFound();
            }
            var ds = dsDanhMuc.Select(dm=>new
            {
                IdDanhMuc = dm.IdDanhMuc,
                TenXe = dm.TenXe
            });
            return Ok(ds);
        }
        // function get danh mucj theo IdDanhMuc 
        [HttpGet("GetDsDanhMucXeById")]
        public async Task<IActionResult> GetDsDanhMucXeById(string IdDanhMuc)
        {
            var danhMuc = await context.DanhMucXes.FirstOrDefaultAsync(dm => dm.IdDanhMuc == IdDanhMuc);
            if (danhMuc == null)
            {
                return NotFound("Không có kết quả nao được tìm thấy");
            }
            var danhMucResult = new
            {
                IdDanhMuc = danhMuc.IdDanhMuc,
                TenXe = danhMuc.TenXe
            };
            return Ok(danhMucResult);
        }

        // function get danh mục theo ten xe
        [HttpGet("GetDsDanhMucByTenXe")]
        public async Task<IActionResult> GetDsDanhMucByTenXe(string TenXe)
        {
            var danhMuc = await context.DanhMucXes.FirstOrDefaultAsync(dm => dm.TenXe == TenXe);
            if (danhMuc == null)
            {
                return NotFound("Không có kết quả nào được tìm thấy");
                
            }
            var danhMucResult = new
            {
                IdDanhMuc = danhMuc.IdDanhMuc,
                TenXe = danhMuc.TenXe
            };
            return Ok(danhMucResult);
        }
        // function get ds xe by idDanhMucXe
        [HttpGet("GetDsXeByIdDanhMucXe")]
        public async Task<IActionResult> GetDsXeByIdDanhMucXe(string idDanhMuc)
        {
            if (idDanhMuc == null)
            {
                return BadRequest("IdDanhMucXe không hợp lệ!");
            }
            var result =await context.DanhMucXes.FirstOrDefaultAsync(dm => dm.IdDanhMuc == idDanhMuc);
            if (result == null)
            {
                return NotFound("Không có kết quả nào được tìm thấy");
            }
            return Ok(result);
        }

        // function thêm danh mục xe 
        [HttpPost("AddDanhMucXe")]
        public async Task<IActionResult> AddDanhMucXe(DanhMucXeVM danhMucXe)
        {
            if(danhMucXe == null)
            {
                return BadRequest("Dữ liệu của danh mục không hợp lệ");
            }
            else
            {
                if(danhMucXe.TenXe == null)
                {
                    return BadRequest("Vui lòng nhập tên xe");
                }
                else
                {
                    var lastIdDanhMuc = context.DanhMucXes
                        .OrderByDescending(dm=>dm.IdDanhMuc)
                        .Select(dm=>dm.IdDanhMuc)
                        .FirstOrDefault();
                    var newIdDanhMucNumber = 1; 
                    if(lastIdDanhMuc != null)
                    {
                        newIdDanhMucNumber = int.Parse(lastIdDanhMuc.Substring(2)) + 1;
                    }

                    try
                    {
                        DanhMucXe newDanhMucXe = new DanhMucXe();
                        newDanhMucXe.IdDanhMuc = $"DMX{newIdDanhMucNumber:D4}";
                        newDanhMucXe.TenXe = danhMucXe.TenXe;
                        context.DanhMucXes.Add(newDanhMucXe);
                        await context.SaveChangesAsync();
                        return Ok(newDanhMucXe) ;
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Lỗi: "+ex.Message);
                        return StatusCode(500, "Có lỗi từ server");
                    }
                }
            }
        }

        // function update danh mục xe
        [HttpPut("UpdateInfoDanhMucXe")]
        public async Task<IActionResult> UpdateDanhMucXe(DanhMucXeVM danhMucXe)
        {
            if (danhMucXe == null)
            {
                return BadRequest("Dữ liệu của danh mục không hợp lệ!");
            }
            else
            {
                if (danhMucXe.TenXe == null)
                {
                    return BadRequest("Vui lòng nhập tên xe");
                }
                else
                {
                    var findDanhMuc = await context.DanhMucXes.FirstOrDefaultAsync(dm=>dm.IdDanhMuc==danhMucXe.IdDanhMuc);
                    if(findDanhMuc == null)
                    {
                        return NotFound("Không tìm thấy danh mục xe");
                    }
                    try
                    {
                        findDanhMuc.TenXe = danhMucXe.TenXe;
                        context.SaveChanges();
                    } catch (Exception ex) {
                        Console.WriteLine("Lỗi: "+ex.Message);
                    }

                }
            }
            return Ok(danhMucXe);
        }
     }
}
