﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("ChiTietDonThue")]
    public class ChiTietDonThue
    {
        [Key]
        [StringLength(7)]
        public string MaCTDT { get; set; }
        [ForeignKey("DonThue")]
        public string MaDT { get; set; }
        public DonThue DonThue { get; set; }
        public string MaXe { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public double? TienCocGuiXe { get; set; } = null;
        public double TienCocXe { get; set; }
        public double ThanhTien { get; set; }
        public string TrangThai { get; set; }
        public string PTThanhToan { get; set; }
        public string TinhTrangBanGiao { get; set; }
        public string AnhMinhChungURL { set; get; } = null;
        public string NoiNhan { get; set; }
        public string NoiTra { set; get; }
        public int? GiaHan { get; set; } = null;
        public DateTime? NgayGiaHan { set; get; } = null;


    }
}
