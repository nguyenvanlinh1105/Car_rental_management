using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("BaiViet")]
    public class BaiViet
    {
        [Key]
        [StringLength(7)]
        public string MaBV { set; get; }
        [ForeignKey("NguoiDung")]
        public string MaND { set; get; }
        public NguoiDung NguoiDung { set; get; }

        public string TieuDe { set; get; }
        public string MoDau { set; get; }
        public string TinhTrang { set; get; }
        public string DanhMuc {  set; get; }
        public string AnhMinhHoaUrl {  set; get; }
        public DateTime NgayDang { set; get; }
        public DateTime NgayCapNhat { get; set; }

        public ICollection<NoiDung> noiDungs { set; get; }

    }
}
