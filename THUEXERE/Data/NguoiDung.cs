using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        [StringLength(7)]
        public string MaND {  get; set; }
        public string HoTen { set; get; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SDT {  get; set; }
        public string CCCD {  get; set; }
        public string GioiTinh {  get; set; }
        public string DiaChi {  get; set; }
        public string TinhTrang { set; get; }
        public string MatKhau { set; get; }
        public string AnhDaiDienUrl {  get; set; }
        public DateTime NgayTao { set; get; }
        public DateTime? NgayCapNhat { set; get; } = null;
    }
}
