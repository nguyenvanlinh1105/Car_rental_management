using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEBAPI.Data;

namespace THUEXERE.ViewModel
{
    public class XeVM
    {
        public string MaXe { get; set; }
        public string IdDanhMuc { get; set; }
        public string IdLoaiXe { set; get; }
        public string IdMauXe { set; get; }
        public string TinhTrang { set; get; }
        public string MoTa { set; get; }
        public string SoKhung { set; get; }
        public string KhoiLuong { set; get; }
        public int NamSX { set; get; }
        public string HinhAnh { set; get; }
        public string BienSo { set; get; }
        public string CongSuat { set; get; }// đơn vị là KW 
    }
}
