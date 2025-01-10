using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("DonThue")]
    public class DonThue
    {
        [Key]
        [StringLength(7)]
        public string MaDT {  get; set; }
        [ForeignKey("KhachHang")]
        public string MaKH { set; get; }
        public NguoiDung KhachHang {  get; set; }
        [ForeignKey("NhanVienHoTro")]
        public string MaNVHT { set; get; }
        public NguoiDung NhanVienHoTro {  get; set; }
        public string PTThanhToan { set; get; }
        public string TinhTrangDon {  set; get; }
        public float TongTien {  set; get; }
        public DateTime NgayTao { set; get; }

        public ICollection<GopY> gopYs { get; set; }
        public ICollection<ChiTietDonThue> chiTietDonThues { get; set; }
        public ICollection<DonThue_DichVu> donThue_DichVus { get; set; }
    }
}
