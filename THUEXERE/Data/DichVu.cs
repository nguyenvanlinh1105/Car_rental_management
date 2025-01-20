using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("DichVu")]
    public class DichVu
    {
        [Key]
        [StringLength(7)]
        public string MaDV { set; get; }
        public string TenDV { set; get; }
        public string AnhMinhHoaUrl {  set; get; }
        public string MoTa { set; get; }
        public string TinhTrang { set; get; }
        public double DonGia {  set; get; }
        public int SoLuong {  set; get; }
        public string HinhThuc {  set; get; }
        public string DonVi { set; get; }
        public string Loai { set; get; }
    }
}
