using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("Xe")]
    public class Xe
    {
        [Key]
        [StringLength(7)]
        public string MaXe {  get; set; }

        [ForeignKey("DanhMucXe")]
        [StringLength(7)]
        public string IdDanhMuc { get; set; }
        public DanhMucXe DanhMucXe { get; set; }

        [ForeignKey("LoaiXe")]
        [StringLength(7)]
        public string IdLoaiXe { set; get; }
        public LoaiXe LoaiXe { set; get; }

        [ForeignKey("MauXe")]
        [StringLength(7)]
        public string IdMauXe { set; get; }
        public MauXe MauXe { get; set; }

        public string TinhTrang { set;get; }

        public string MoTa { set; get; }
        public string SoKhung {  set; get; }
        public string KhoiLuong { set; get; }
        public int NamSX {  set; get; }
        public string HinhAnh {  set; get; }
        public string BienSo { set; get; }
        public string CongSuat {  set; get; }// đơn vị là KW 


    }
}
