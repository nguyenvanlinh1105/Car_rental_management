using System.ComponentModel.DataAnnotations.Schema;
using System;
using WEBAPI.Data;
using System.Collections.Generic;

namespace THUEXERE.ViewModel
{
    public class DonThueVM
    {
        public string MaDT { get; set; }
        public string MaKH { set; get; }
        public string MaNVHT { set; get; }
        public string PTThanhToan { set; get; }
        public string TinhTrangDon { set; get; }
        public float TongTien { set; get; }
        public DateTime? NgayTao { set; get; }= DateTime.Now;

        public ICollection<ChiTietDonThueVM> chiTietDonThues { get; set; }
    }
}
