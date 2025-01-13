using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Data;
using THUEXERE.ViewModel;


namespace THUEXERE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiXeController : ControllerBase
    {
        private readonly WebDbContext context;

        public LoaiXeController(WebDbContext _context)
        {
            this.context = _context;
        }

        // function lấy danh sách loại xe 
        [HttpGet]
        public async Task<IActionResult> GetDSLoaiXe()
        {
            var dsLoaiXe = await context.LoaiXes.ToListAsync();
            if (dsLoaiXe == null)
            {
                return NotFound("Danh sách loại xe null");
            }
            var ds = dsLoaiXe.Select(lx => new
            {
                IdLoaiXe = lx.IdLoaiXe,
                LoaiXe = lx.loaiXe
            });
            return Ok(ds); 
        }
        // function lấy loại xe theo id 
        [HttpGet("GetLoaiXeByID/{IdLoaiXe}")]
        public async Task<IActionResult> GetLoaiXeById(string IdLoaiXe)
        {
            try
            {
                var loaiXe = await context.LoaiXes.FirstOrDefaultAsync(lx => lx.IdLoaiXe == IdLoaiXe);
                if (loaiXe == null)
                {
                    return NotFound("Không tìm thấy loại xe.");
                }
                var result = new
                {
                    IdLoaiXe = loaiXe.IdLoaiXe,
                    LoaiXe = loaiXe.loaiXe
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return StatusCode(500, "Có lỗi xảy ra trên server.");
            }
        }
        // function lấy xe theo loại xe 
        [HttpGet("GetDsXeByIdLoaiXe")]
        public async Task<IActionResult> GetDsXeByIdLoaiXe(string IdLoaiXe)
        {
            var result = await context.LoaiXes.FirstOrDefaultAsync(lx => lx.IdLoaiXe == IdLoaiXe);
            if (IdLoaiXe == null)
            {
                return NotFound("Không có kết quả nào đượct tìm thấy");
            }
            return Ok(result);
        }

        // function thêm loai xe 
        [HttpPost("AddLoaiXe")]
        public async Task<IActionResult>AddLoaiXe(LoaiXeVM loaiXe)
        {

            if(loaiXe == null)
            {
                return BadRequest("Dữ liệu loại xe không hợp lệ, vui lòng truyền đúng dữ liệu");
            }
            else
            {
                if(loaiXe.loaiXe == null)
                {
                    return BadRequest("Vui lòng nhập tên loại xe");
                }
                else
                {
                    string lastId = context.LoaiXes
                      .OrderByDescending(lx => lx.IdLoaiXe)
                      .Select(lx => lx.IdLoaiXe)
                      .FirstOrDefault();

                    int newIdLoaiXe = 1;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        newIdLoaiXe = int.Parse(lastId.Substring(2)) + 1;
                    }
                    try
                    {
                        LoaiXe newLoaiXe = new LoaiXe();
                        newLoaiXe.IdLoaiXe = $"LX{newIdLoaiXe:D5}";
                        newLoaiXe.loaiXe = loaiXe.loaiXe;
                        context.LoaiXes.Add(newLoaiXe);
                        await context.SaveChangesAsync();
                        return Ok(newLoaiXe);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Lỗi: "+ ex.Message);
                        return StatusCode(500, "Có lỗi xảy ra trên server.");
                    }
                }
            }
           
        }

        [HttpPut("UpdateInfoLoaiXe")]
        public async Task<IActionResult> UpdateInfoLoaiXe(LoaiXe loaiXe)
        {
            if (loaiXe == null)
            {
                return BadRequest("Dữ liệu loại xe không chính xác!");

            }
            else
            {
                if (loaiXe.loaiXe == null)
                {
                    return BadRequest("Vui lòng nhập tên loại xe");

                }
                else
                {
                    var findLoaiXe = await context.LoaiXes.FirstOrDefaultAsync(lx => lx.IdLoaiXe == loaiXe.IdLoaiXe);
                    if (findLoaiXe == null)
                    {
                        return NotFound("Không tìm thấy loại xe.");
                    }
                    else
                    {
                        try
                        {
                            findLoaiXe.loaiXe = loaiXe.loaiXe;
                            await context.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi: " + ex.Message);
                            return StatusCode(500, "Có lỗi xảy ra trên server.");
                        }

                    }
                }
                return Ok();
            }
        }

        //function tìm kiếm loại xe theo tên 
        [HttpGet("GetLoaiXeByLoaiXe")]
        public async Task<IActionResult> GetLoaiXeByName(string tenloaiXe)
        {
            if(tenloaiXe == null)
            {
                return BadRequest("Tên loại xe không hợp lệ");
            }
            var loaiXe = await context.LoaiXes.FirstOrDefaultAsync(lx =>lx.loaiXe==tenloaiXe);
            if(loaiXe == null)
            {
                return NotFound("Không tìm thấy loại xe");
            }
            var result = new
            {
                IdLoaiXe = loaiXe.IdLoaiXe,
                loaiXe = loaiXe.loaiXe
            };
            return Ok(result);
        }


    }
}
